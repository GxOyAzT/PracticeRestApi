using System;
using System.Collections.Generic;
using System.Linq;

namespace AllBackgroundStuff
{
    public class ModelARepo : IModelARepo
    {
        public ModelARepo()
        {
            Models = new List<ModelA>()
            {
                new ModelA()
                {
                    PropInt = 10,
                    PropDouble = 10.99F,
                    PropGuid = Guid.Parse("8724f477-a21e-42c8-9519-57e97e52d67d"),
                    PropDateTime = new DateTime(2000,3,1,15,54,5),
                    PropString = "xyz@gmail.com",
                    PropModelEnum = ModelEnum.EnumProp2
                },
                new ModelA()
                {
                    PropInt = 7,
                    PropDouble = 0F,
                    PropGuid = Guid.Parse("474f18f7-0075-4c30-a6b2-f27473e760ce"),
                    PropDateTime = new DateTime(1987,5,30),
                    PropString = "abc@gmail.com",
                    PropModelEnum = ModelEnum.EnumProp3
                }
            };
        }

        public List<ModelA> Models;

        public void Create(ModelA modelA) => Models.Add(modelA);

        public ModelA Get(int propInt) => Models.FirstOrDefault(e => e.PropInt == propInt);

        public List<ModelA> GetAll() => Models;

        public void Update(ModelA modelA)
        {
            var objectToUpdate = Models.FirstOrDefault(e => e.PropInt == modelA.PropInt);

            objectToUpdate = modelA;
        }

        public void Delete(ModelA modelA)
        {
            if (modelA is null)
                throw new ArgumentNullException(nameof(modelA));

            Models.Remove(modelA);
        }
    }
}
