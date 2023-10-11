using NewSpecificationLib.RestClasses;
using System;
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
        public List<Specification> SpecsToUpdate { get; set; } = new List<Specification>();
        private List<ReturnClasses.Specification> _specificationsToVerify { get; set; } = new List<ReturnClasses.Specification>();
    public SpecLibGeter() : base("https://partner.prodmasterpro.ru:5443/")
        {
            ServicePointManager
            .ServerCertificateValidationCallback +=
            (sender, cert, chain, sslPolicyErrors) => true;
        }

        public void SetTestMode()
        {
            ServerUrl = "http://localhost:5656/";
        }
        public void SetTestModeLocal(string url)
        {
            ServerUrl = url;
        }

        public void TestInitSpecsToVerify(long id)
        {
            _specificationsToVerify.Add(new ReturnClasses.Specification() { Id = id });
        }

        public ArrayList GetNewSpecs()
        {
            try
            {
                var getNewSpecsUri = ServerUrl + "api/specifications";
                var res = GetData<List<RestClasses.Specification>>(getNewSpecsUri);
                CurNewSpecIds.Clear();
                foreach (var spec in res)
                {
                    _specificationsToVerify.Add(new ReturnClasses.Specification() { Id = spec.Id });
                    foreach (var p in spec.Products)
                    {

                        _specificationsToVerify.Last().Products.Add(new ReturnClasses.Product() { Id = p.Id });
                    }
                }
                foreach (var spec in res) { CurNewSpecIds.Add(spec.Id); }
                return PrepareDisanArr(res);
            }
            catch (Exception)
            {
                return new ArrayList();
            }
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
                    CustomId = spec.CustomId,
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

        public void AddSpecificationToPatchList(long id, long disanId, long customId)
        {
            var specification = _specificationsToVerify.FirstOrDefault(s => s.Id == id);
            if (specification != null)
            {
                specification.DisanId = disanId;
                specification.CustomId = customId;
                specification.IsVerified = true;
            }
        }

        public void AddProductToPatchList(long id, long productId, long disanId)
        {
            var specification = _specificationsToVerify.FirstOrDefault(s => s.Id == id);
            if (specification != null)
            {
                var product = specification.Products.FirstOrDefault(p => p.Id == productId);
                if(product != null)
                {
                    product.DisanId = disanId;
                    product.IsVerified = true;
                }
            }
        }

        public string PatchNewSpecs()
        {
            var patchNewSpecsUri = ServerUrl + "api/specificationsToVerify";
            return PatchData<string, List<ReturnClasses.Specification>>(patchNewSpecsUri, _specificationsToVerify);
        }
    }
}