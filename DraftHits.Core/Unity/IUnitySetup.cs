using Microsoft.Practices.Unity;

namespace DraftHits.Core.Unity
{
    public interface IUnitySetup
    {
        IUnityContainer RegisterTypes(IUnityContainer container);
    }
}
