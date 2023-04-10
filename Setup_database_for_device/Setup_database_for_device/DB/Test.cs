namespace Setup_database_for_device.DB
{
    class Test
    {

        private string GetIdByOrdinal(int ordinal)
        {
            string result = "00" + ordinal.ToString();
            return result.Substring(result.Length - 3);
        }

        private string GetGroupTagIdByTagGroupOrdinalAndIndex(int ordinal, int index)
        {
            string first_part = GetIdByOrdinal(ordinal);
            string second_part = "0" + index.ToString();
            return first_part + "н" + second_part.Substring(second_part.Length - 2);
        }

        public Test()
        {
            DateBase db = new DateBase("", "TSPT963", "0");

            Channel channel = new Channel("0", "0", "Common", "0", "системный канал");

            channel.AddTag(new Tag(1, GetIdByOrdinal(1)));
            channel.AddTag(new Tag(3, GetIdByOrdinal(3)));
            channel.AddTag(new Tag(4, GetIdByOrdinal(4)));
            channel.AddTag(new Tag(5, GetIdByOrdinal(5)));
            channel.AddTag(new Tag(8, GetIdByOrdinal(8)));
            channel.AddTag(new Tag(11, GetIdByOrdinal(11)));
            channel.AddTag(new Tag(12, GetIdByOrdinal(12)));
            channel.AddTag(new Tag(21, GetIdByOrdinal(21)));
            channel.AddTag(new Tag(20, GetIdByOrdinal(20)));
            channel.AddTag(new Tag(23, GetIdByOrdinal(23)));
            channel.AddTag(new Tag(24, GetIdByOrdinal(24)));
            channel.AddTag(new Tag(25, GetIdByOrdinal(25)));

            TagGroup ord6 = new TagGroup(6);
            for(int i = 0; i <= 34; i++)
            {
                ord6.AddNewTag(new GroupTag(i, GetGroupTagIdByTagGroupOrdinalAndIndex(6, i), "0.0.0.0"));
            }

            channel.AddTagGroup(ord6);

            //Second channel
            int no = 1;
            string prefix = "т";
            string name = prefix + no.ToString();
            Channel channel2 = new Channel(no.ToString(), name, "Channel", prefix, "трубопровод");

            channel2.AddTag(new Tag(100, GetIdByOrdinal(100) + name, "1", "Nтруб"));
            channel2.AddTag(new Tag(101, GetIdByOrdinal(101) + name, "1", "Тплнс"));

            TagGroup ord102 = new TagGroup(102);

            ord102.AddNewTag(new GroupTag(0, GetGroupTagIdByTagGroupOrdinalAndIndex(102, 0) + name, "2", "ТипД"));
            ord102.AddNewTag(new GroupTag(1, GetGroupTagIdByTagGroupOrdinalAndIndex(102, 1) + name, "250", "D20", "мм"));
            ord102.AddNewTag(new GroupTag(2, GetGroupTagIdByTagGroupOrdinalAndIndex(102, 2) + name, "1.25e-05", "Вт", "1/'c"));
            ord102.AddNewTag(new GroupTag(3, GetGroupTagIdByTagGroupOrdinalAndIndex(102, 3) + name, "21", "Rш/A", "мм"));

            channel2.AddTagGroup(ord102);

            db.AddChannel(channel);
            db.AddChannel(channel2);

            db.SaveDBToFile("db2", "xdb");
        
        }
    }
}
