using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup_database_for_device.DB
{
    class Test
    {
        public Test()
        {
            DateBase db = new DateBase("12", "SP12", "Vlad");

            Channel channel = new Channel("1", "first_channel", "kind", "p");

            TagGroup tagGroup = new TagGroup("20", "first group");

            for(int i = 0; i < 10; i++)
            {
                GroupTag groupTag1 = new GroupTag(i.ToString(), $"tag-{i}");
                tagGroup.AddNewTag(groupTag1);
            }
            channel.AddTagGroup(tagGroup);

            for (int i = 1; i < 10; i++)
            {
                Tag tag = new Tag(i.ToString(), $"tagGroup-{i}");
                channel.AddTag(tag);
            }

            db.AddChannel(channel);

            db.AddChannel(new Channel("12", "second_channel", "kind", "p"));

            db.SaveDBToFile("db", "xml");

            for (int i = 10; i < 20; i++)
            {
                GroupTag groupTag1 = new GroupTag(i.ToString(), $"tagGroup-{i}");
                tagGroup.AddNewTag(groupTag1);
            }
            db.SaveDBToFile("db2", "xml");

            Channel[] channelList = db.GetChannelListByPrefix("p");
            Channel foundChannel = db.getChannelByName("second_channel");

            AbstractTag tagInTagGroup = db.GetTagById("tagGroup-8");
            AbstractTag tagInChannel = db.GetTagById("tag-4");

            GroupTag tagInTagGroupByIndex = tagGroup.GetGroupTagByIndex("4");

            Tag tagInChannelByOrdinal = channel.GetTagByOrdinal("8");
            TagGroup tagGroupInChannelByOrdinal = channel.GetTagGroupByOrdinal("20");

            int a = 10;
        }
    }
}
