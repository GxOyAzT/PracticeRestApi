using System.Collections.Generic;

namespace AllBackgroundStuff
{
    public interface IModelARepo
    {
        void Create(ModelA modelA);
        void Update(ModelA modelA);
        List<ModelA> GetAll();
        ModelA Get(int propInt);
        void Delete(ModelA modelA);
    }
}
