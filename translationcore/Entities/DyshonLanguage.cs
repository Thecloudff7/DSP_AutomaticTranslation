using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace translationcore.Entities {


    public class RootObject {
        [JsonProperty("TranslationTable")]
        public List<DyshonLanguage> TranslationTable { get; set; }
    }

    public class DyshonLanguage {
        public bool IsValid { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string Original { get; set; }
        public string Translation { get; set; }
    }
}
