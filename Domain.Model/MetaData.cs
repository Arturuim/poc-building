namespace Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public  class MetaData
    {
        public MetaDataType Type { get; set; }
        public string Link { get; set; }
        public Dictionary<string, string> Info { get; set; }
    }

    public  enum  MetaDataType { }
}
