using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Requests = WhereAreYou.Core.Requests;
using Responses = WhereAreYou.Core.Responses;
using Entity = WhereAreYou.Core.Entity;
using Model = WhereAreYou.Core.Model;

namespace WhereAreYou.RoomApi.Tests
{
    [TestClass]
    public class Utils
    {
        const string BASE_PATH = @"C:\Users\petr\Documents\way\WhereAreYou\wwwroot\js";

        [TestMethod]
        public void GenerateViewModel()
        {
            GenerateViewModel(typeof(Entity.Room));
            GenerateViewModel(typeof(Entity.User));
            GenerateViewModel(typeof(Entity.Location));
            GenerateViewModel(typeof(Entity.Position));
            GenerateViewModel(typeof(Entity.AdvertPosition));

            GenerateViewModel(typeof(Requests.CreateRoom));
            GenerateViewModel(typeof(Requests.EnterTheRoom));
            GenerateViewModel(typeof(Requests.UpdatePosition));

            GenerateViewModel(typeof(Responses.CreatedRoom));
            GenerateViewModel(typeof(Responses.Token));

            GenerateViewModel(typeof(Model.UserData));
        }

        private void GenerateViewModel(Type type)
        {
            var className = type.Name.ToString();

            var options = new Castle.Sharp2Js.JsGeneratorOptions()
            {
                CamelCase = true,
                OutputNamespace = "way.models",
                IncludeMergeFunction = false,
                ClassNameConstantsToRemove = null,
                RespectDataMemberAttribute = true,
                RespectDefaultValueAttribute = true,
                TreatEnumsAsStrings = false
            };

            var fileName = String.Concat(className, ".js");
            var path = Path.Combine(BASE_PATH, fileName);
            var model = Castle.Sharp2Js.JsGenerator.Generate(new[] { type }, options);

            File.WriteAllText(path, model);
        }
    }
}
