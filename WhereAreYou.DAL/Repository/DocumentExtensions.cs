using Microsoft.Azure.Documents;
using WhereAreYou.Core.Entity;

namespace WhereAreYou.DAL.Repository
{
    public static class DocumentExtensions
    {
        public static IWay ToWay(this Document document)
        {
            return new WayBase(document.Id);
        }
    }
}