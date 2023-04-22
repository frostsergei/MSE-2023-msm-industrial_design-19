using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Setup_database_for_device.DB;

namespace Setup_database_for_device.Model
{
    class Model
    {
        private SystemWideSettings _systemWideSettings;

        private List<Pipeline> _pipelines;

        private List<Consumer> _consumers;

        public enum Device
        {
            SPT961,
            SPT962,
            SPT963
        }

        private Device _device;

        public SystemWideSettings SystemWideSettings
        {
            get { return _systemWideSettings; }
        }

        public Device CurrentDevice
        {
            get { return _device; }
            set
            {
                _device = value;
                int newPipelinesCount = 12;
                int newConsumersCount = 6;
                if (_device == Device.SPT963)
                {
                    newPipelinesCount = 16;
                    newConsumersCount = 8;
                }
                _systemWideSettings.PipelinesCount = newPipelinesCount;
                _systemWideSettings.ConsumersCount = newConsumersCount;
                foreach (var consumer in _consumers)
                {
                    consumer.PipelinesCount = newPipelinesCount;
                }
                if (_pipelines.Count < newPipelinesCount)
                {
                    for (int i = 0; i < newPipelinesCount - _pipelines.Count; i++)
                    {
                        _pipelines.Add(new Pipeline());
                    }
                }
                if (_consumers.Count < newConsumersCount)
                {
                    for (int i = 0; i < newConsumersCount - _consumers.Count; i++)
                    {
                        _consumers.Add(new Consumer(newPipelinesCount));
                    }
                }
            }
        }

        public Model(Device device)
        {
            _device = device;
            int pipelinesCount = 12;
            int consumersCount = 6;
            if (_device == Device.SPT963)
            {
                pipelinesCount = 16;
                consumersCount = 8;
            }
            _pipelines = new List<Pipeline>();
            for (int i = 0; i < pipelinesCount; i++)
            {
                _pipelines.Add(new Pipeline());
            }
            _consumers = new List<Consumer>();
            for (int i = 0; i < consumersCount; i++)
            {
                _consumers.Add(new Consumer(pipelinesCount));
            }
            _systemWideSettings = new SystemWideSettings(pipelinesCount, consumersCount);
        }

        public Consumer GetConsumerByInd(int index)
        {
            return _consumers[index];
        }

        public Pipeline GetPipelineByInd(int index)
        {
            return _pipelines[index];
        }

        public void SaveDataToFile(string path, string serialNumber)
        {
            string targetDevice = "";
            switch (_device)
            {
                case Device.SPT961:
                    targetDevice = "TSPT961";
                    break;
                case Device.SPT962:
                    targetDevice = "TSPT962";
                    break;
                case Device.SPT963:
                    targetDevice = "TSPT963";
                    break;
                default:
                    break;
            }
            DateBase dataBase = new DateBase(serialNumber, targetDevice, "0");

            //Внесение общесистемных параметров
            Channel systemWideChannel = new Channel("0", "0", "Common", "0", "системный канал");
            Dictionary<string, Parameter> parameters = _systemWideSettings.Parameters;
            List<TagGroup> tagGroups = new List<TagGroup>();
            foreach (var item in parameters)
            {
                string name = item.Key;
                Parameter parameter = item.Value;
                if (name.Contains("н") == false)
                {
                    systemWideChannel.AddTag(new Tag(Int32.Parse(name), name, parameter.Value, "", parameter.UnitOfMeasurement));
                }
                else
                {
                    int ordinal = Int32.Parse(name.Substring(0,3));
                    int index = Int32.Parse(name.Substring(4, 2));
                    TagGroup currentTagGroup = null;
                    foreach (var tagGroup in tagGroups)
                    {
                        if (tagGroup.Ordinal == ordinal) currentTagGroup = tagGroup;
                    }
                    if (currentTagGroup == null)
                    {
                        currentTagGroup = new TagGroup(ordinal);
                        tagGroups.Add(currentTagGroup);
                    }
                    currentTagGroup.AddNewTag(new GroupTag(index, name, parameter.Value, "", parameter.UnitOfMeasurement));
                }
            }
            foreach (var tagGroup in tagGroups)
            {
                systemWideChannel.AddTagGroup(tagGroup);
            }
            dataBase.AddChannel(systemWideChannel);

            //Внесение информации по трубопроводам
            List<Channel> channelsListT = new List<Channel>();
            List<Channel> channelsListK = new List<Channel>();
            for (int i = 0; i < _pipelines.Count; i++)
            {
                if (_pipelines[i].Active == false) continue;
                Pipeline currentPipeline = _pipelines[i];
                parameters = currentPipeline.Parameters;
                bool freqWater = false; // относится ли к листу "Чатота вода"
                bool impSteam = false; //относится ли к листу "Имп пар"
                if (parameters["034н00"].Value.Contains("3") || parameters["034н00"].Value.Contains("4")) // Условие перехода на лист "Частота вода"
                    freqWater = true;
                if (parameters["101"].Value.Contains("1") || parameters["101"].Value.Contains("2")) // Условие перехода на лист "Частота вода"
                    impSteam = true;
                tagGroups = new List<TagGroup>();
                string suffixT = "т" + (i + 1).ToString();
                string suffixK = "к" + (i + 1).ToString();
                Channel channelT = new Channel((i + 1).ToString(), suffixT, "Channel", "т", "трубопровод");
                Channel channelK = new Channel((i + 1).ToString(), suffixK, "Channel", "к", "доп.канал");
                channelT.AddTag(new Tag(100, "100" + suffixT, (i + 1).ToString(), "", "")); // номер трубопровода
                foreach (var item in parameters)
                {
                    string name = item.Key;
                    Parameter parameter = item.Value;

                    if (name == "034н06" || name == "034н07") // Только для листа "Частота вода"
                        if (freqWater == false)
                            continue;

                    if (name == "104" || name == "105") // Только для листа "Имп Пар"
                        if (impSteam == false)
                            continue;

                    if (name == "034н08" && freqWater == true) // Для всех, кроме "Частота вода"
                        continue;

                    if (name.Contains("н") == false)
                    {
                        channelT.AddTag(new Tag(Int32.Parse(name), name + suffixT, parameter.Value, "", parameter.UnitOfMeasurement));
                    }
                    else
                    {
                        int ordinal = Int32.Parse(name.Substring(0, 3));
                        int index = Int32.Parse(name.Substring(4, 2));
                        TagGroup currentTagGroup = null;
                        foreach (var tagGroup in tagGroups)
                        {
                            if (tagGroup.Ordinal == ordinal) currentTagGroup = tagGroup;
                        }
                        if (currentTagGroup == null)
                        {
                            currentTagGroup = new TagGroup(ordinal);
                            tagGroups.Add(currentTagGroup);
                        }
                        if (ordinal >= 30 && ordinal < 100) // параметры для каналов
                            currentTagGroup.AddNewTag(new GroupTag(index, name+suffixK, parameter.Value, "", parameter.UnitOfMeasurement));
                        else //параметры трубопроводов
                            currentTagGroup.AddNewTag(new GroupTag(index, name + suffixT, parameter.Value, "", parameter.UnitOfMeasurement));
                    }
                }
                foreach (var tagGroup in tagGroups)
                {
                    if (tagGroup.Ordinal >= 30 && tagGroup.Ordinal < 100)
                        channelK.AddTagGroup(tagGroup);
                    else
                        channelT.AddTagGroup(tagGroup);
                }
                channelsListK.Add(channelK);
                channelsListT.Add(channelT);
            }

            foreach (var channel in channelsListT)
                dataBase.AddChannel(channel);

            foreach (var channel in channelsListK)
                dataBase.AddChannel(channel);

            //Внесение информации по потребителям
            for (int i = 0; i < _consumers.Count; i++)
            {
                if (_consumers[i].Active == false) continue;
                string suffixP = "п" + (i + 1).ToString();
                Channel consumerChannel = new Channel((i + 1).ToString(), suffixP, "Group", "п", "магистраль");
                Consumer currentConsumer = _consumers[i];
                consumerChannel.AddTag(new Tag(300, "300" + suffixP, currentConsumer.Id.ToString(), "", ""));
                string param301 = "";
                for (int j = 0; j < _systemWideSettings.PipelinesCount; j++)
                {
                    if (_pipelines[j].Active == false)
                    {
                        param301 = param301 + "0";
                    }
                    else
                    {
                        param301 = param301 + ((int)currentConsumer.GetPipelineStatusByInd(j)).ToString();
                    }
                }
                param301 = param301 + currentConsumer.AccountingSchemeNumber.ToString();
                consumerChannel.AddTag(new Tag(301, "301" + suffixP, param301, "", ""));
                dataBase.AddChannel(consumerChannel);
            }

            dataBase.SaveDBToFile(path, "xdb");
        }
    }
}
