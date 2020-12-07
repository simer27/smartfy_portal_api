using System;
using System.Collections.Generic;
using System.Linq;
using smartfy.portal_api.domain.Entities;

namespace smartfy.portal_api.Infra.DataManager
{
    public class CoreDataManager : DataManager
    {
        public override void Seed()
        {
            InjectAllData();
        }

        public async void InjectAllData()
        {
        }
    }
}
