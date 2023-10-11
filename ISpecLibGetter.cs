using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NewSpecificationLib
{
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("E90C2A3F-A0BE-46F3-B4C2-83AA8FCCBD99")]
    public interface ISpecLibGetter
    {
        void SetTestMode();
        ArrayList GetNewSpecs();

        ArrayList PrepareDisanArr(List<RestClasses.Specification> list);
        void AddSpecificationToPatchList(long id, long disanId, long customId);
        void AddProductToPatchList(long id, long productId, long disanId);
        string PatchNewSpecs();
    }
}