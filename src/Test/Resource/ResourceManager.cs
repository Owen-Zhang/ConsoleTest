using System;
using System.IO;
using System.Resources;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace Test.Resource
{
    public class ResourceGenerater
    {
        public static void GenerateResxFile()
        {
            var resxFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BusinessError.resx");
            using (var writer = new ResXResourceWriter(resxFile))
            {
                writer.AddResource("DataFormat_Solr", "yyyy-MM-ddTHH:mm:ss.fffZ");  
            }
            string designFilePath = resxFile.Replace(".resx", ".designer.cs");

            var codeProvider = new Microsoft.CSharp.CSharpCodeProvider();
            string[] unmatchedElements;

            var keyValues = new Dictionary<object, object>();
            using (ResXResourceReader rsxr = new ResXResourceReader(resxFile))
            {
                rsxr.BasePath =  new FileInfo(resxFile).Directory.FullName;
                rsxr.UseResXDataNodes = true;

                foreach (DictionaryEntry d_loopVariable in rsxr)
                {
                    keyValues.Add(d_loopVariable.Key, d_loopVariable.Value);
                }
            }

            System.CodeDom.CodeCompileUnit code =
            System.Resources.Tools.StronglyTypedResourceBuilder.Create(
               keyValues,
               "BusinessError",
               "Owen.Site.Resouce",
               codeProvider,
               false,
               out unmatchedElements);

            using (StreamWriter writer = new StreamWriter(designFilePath, false, System.Text.Encoding.UTF8))
            {
                codeProvider.GenerateCodeFromCompileUnit(code, writer, new System.CodeDom.Compiler.CodeGeneratorOptions());
            }
        }
    }
}
