using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

namespace NewSpecificationLib
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("8F4E036B-3A83-42E5-84A1-BE8CD2E1361A")]
    [ProgId("NewSpecificationLib.SpecLibGeter")]
    public class SpecLibGeter: CommonClient, ISpecLibGetter
    {
        public List<int> CurNewSpecIds { get; set; } = new List<int>();
        public SpecLibGeter() : base("https://partner.prodmasterpro.ru:5443/")
        {
            ServicePointManager
            .ServerCertificateValidationCallback +=
            (sender, cert, chain, sslPolicyErrors) => true;
        }

        public ArrayList GetNewSpecs()
        {
            var getNewSpecsUri = ServerUrl + "api/specifications";
            var res = GetData<List<RestClasses.Specification>>(getNewSpecsUri);
            CurNewSpecIds.Clear();
            foreach (var spec in res) { CurNewSpecIds.Add(spec.Id); }
            return PrepareDisanArr(res);
        }

        public ArrayList PrepareDisanArr(List<RestClasses.Specification> list)
        {
            var res = new ArrayList();
            foreach (RestClasses.Specification spec in list)
            {
                var disanSpec = new DisanRestClasses.Specification
                {
                    Id = spec.Id,
                    StartsAt = spec.StartsAt,
                    ExpiresAt = spec.ExpiresAt,
                    UserId = spec.UserId,
                    ProvidersName = spec.ProvidersName,
                    Inn = spec.Inn,
                    Email = spec.Email,
                    Phone = spec.Phone,
                    Products = new ArrayList(),
                    CreatedAt = spec.CreatedAt,
                    LastModified = spec.LastModified
                };

                foreach (var prod in spec.Products)
                {
                    disanSpec.Products.Add(prod);
                }
                
                res.Add(disanSpec);
            }

            return res;
        }

        public string PatchNewSpecs()
        {
            //var procSpecIds = new List<int>();
            //foreach (DisanRestClasses.Specification spec in CurNewSpecs)
            //{ procSpecIds.Add(spec.Id); }

            var patchNewSpecsUri = ServerUrl + "api/specificationsToVerify";
            return PostData<string, List<int>>(patchNewSpecsUri, CurNewSpecIds);
        }
    }
}
