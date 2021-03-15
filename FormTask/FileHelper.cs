using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormTask
{
    class FileHelper
    {
        public static void JsonSerialize(string filename, Person person)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter($"{filename}.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, person);
                }
            }
        }

        public static Person JsonDeserialize(string filename)
        {
            Person person = new Person();
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader($"{filename}.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    person = serializer.Deserialize<Person>(jr);
                }
            }
            return person;
        }
    }
}
