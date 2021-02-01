using Google.Cloud.Translation.V2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using translationcore.Entities;

namespace translationcore {
    class Program {
        static void Main(string[] args) {
            GCloudAuth.AuthImplicit("translationcore");

            string path = @"C:\Users\Claudio\Documents\gcloud\translation.json";
            TranslationClient client = TranslationClient.Create();
            using (StreamReader r = new StreamReader(path)) {
                string json = r.ReadToEnd();

                RootObject jDyshon =  JsonConvert.DeserializeObject<RootObject>(json);


                foreach (DyshonLanguage dyshon in jDyshon.TranslationTable) {
                    if (dyshon.IsValid) { 
                    TranslationResult result = client.TranslateText(dyshon.Original, LanguageCodes.Spanish);
                    Console.WriteLine($"Resultado de la traducción con id({dyshon.Id}): {result.TranslatedText}, original: {result.OriginalText}");

                        jDyshon.TranslationTable.FirstOrDefault(k => k.Id == dyshon.Id).Translation = result.TranslatedText;

                        string jsonresult = JsonConvert.SerializeObject(jDyshon);

                        System.IO.File.WriteAllText(@"C:\Users\Claudio\Documents\gcloud\translation_ES.json", jsonresult);
                    }
                }

                Console.WriteLine("Archivo traducido correctamente");

            }
        }
    }
}
