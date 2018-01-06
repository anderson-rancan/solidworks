using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace CrossfireSW.Util
{
    public static class Composition
    {
        public static void Compose(object attributedPart)
        {
            var catalog = new AggregateCatalog();

            AppDomain.CurrentDomain
                .GetAssemblies()
                .ToList()
                .ForEach(_ => catalog.Catalogs.Add(new AssemblyCatalog(_)));

            var container = new CompositionContainer(catalog);
            container.SatisfyImportsOnce(attributedPart);
        }
    }
}
