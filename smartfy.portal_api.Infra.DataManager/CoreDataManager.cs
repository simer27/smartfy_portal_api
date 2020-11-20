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
            Console.WriteLine("  LOADING REGION...");
            #region REGION
            var regions = new List<Region>() {
                new Region("LESTE"),
                new Region("SUL"),
                new Region("OESTE"),
                new Region("NORTE"),
            };

            foreach (var item in regions){
                var dbRegister = _dbContext.Regions.FirstOrDefault(_ => _.Code.Equals(item.Code));
                if (dbRegister == null)_dbContext.Regions.Add(item);
                else _dbContext.Update(dbRegister);
            }
            #endregion

            _dbContext.SaveChanges();
            Console.WriteLine("  LOADING AREA...");
            #region AREA
            var areas = new List<Area>();
            for (int i = 0; i < 10 ; i++)
            {
                areas.Add(new Area($"Area {i.ToString("000")}"));
            }

            foreach (var item in areas) {
                var dbRegister = _dbContext.Areas.FirstOrDefault(_ => _.Name.Equals(item.Name));
                if (dbRegister == null) _dbContext.Areas.Add(item);
                else _dbContext.Update(dbRegister);
            }
            #endregion

            _dbContext.SaveChanges();
            Console.WriteLine("  LOADING PARTNER...");
            #region PARTNER
            var partners = new List<Partner>();
            for (int i = 0; i < 10; i++)
            {
                partners.Add(new Partner($"Empresa {i.ToString("000")}", $"empresa_{i.ToString("000")}@teste.com"));
            }

            foreach (var item in partners)
            {
                var dbRegister = _dbContext.Partners.FirstOrDefault(_ => _.Name.Equals(item.Name));
                if (dbRegister == null) _dbContext.Partners.Add(item);
                else _dbContext.Update(dbRegister);
            }
            #endregion

            _dbContext.SaveChanges();
            Console.WriteLine("  LOADING TEAM...");
            #region TEAM
            var teams = new List<Team>();
            for (int i = 0; i < 500; i++)
            {
                teams.Add(new Team(
                    $"Equipe {i.ToString("000")}",
                    $"PWC-{i.ToString("0000")}",
                    areas.ElementAt(new Random().Next(1, areas.Count)).Id,
                    partners.ElementAt(new Random().Next(1, partners.Count)).Id));
            }

            foreach (var item in teams)
            {
                var dbRegister = _dbContext.Teams.FirstOrDefault(_ => _.Code.Equals(item.Code));
                if (dbRegister == null) _dbContext.Teams.Add(item);
                else _dbContext.Update(dbRegister);
            }
            #endregion

            _dbContext.SaveChanges();
            Console.WriteLine("  LOADING CAMERA...");
            #region CAMERA
            var cameras = new List<Camera>();
            for (int i = 0; i < 5000; i++)
            {
                cameras.Add(new Camera(
                    $"CEMIG_{i.ToString("000")}",
                    "PWC EH-16",
                    "EYELOG",
                    teams.ElementAt(new Random().Next(1, teams.Count)).Id));
            }

            foreach (var item in cameras)
            {
                var dbRegister = _dbContext.Cameras.FirstOrDefault(_ => _.Code.Equals(item.Code));
                if (dbRegister == null) _dbContext.Cameras.Add(item);
                else _dbContext.Update(dbRegister);
            }
            #endregion

            _dbContext.SaveChanges();
            Console.WriteLine("  LOADING DOCKSTATION...");
            #region DOCKSTATION
            var docks = new List<Dockstation>();
            for (int i = 0; i < 70; i++)
            {
                docks.Add(new Dockstation(
                    partners.ElementAt(new Random().Next(1, partners.Count)).Id,
                    $"UNIDADE {i.ToString("000")}"));
            }

            foreach (var item in docks)
            {
                var dbRegister = _dbContext.Dockstations.FirstOrDefault(_ => _.Code.Equals(item.Code));
                if (dbRegister == null) _dbContext.Dockstations.Add(item);
                else _dbContext.Update(dbRegister);
            }
            #endregion

            _dbContext.SaveChanges();
            Console.WriteLine("  LOADING DISK...");
            #region DISK
            var disks = new List<Disk>();
            foreach (var item in docks) {
                disks.Add(new Disk(item.Id,"E:",4096));
            }

            foreach (var item in disks)
            {
                var dbRegister = _dbContext.Disks.FirstOrDefault(_ => item.Name.Equals(item.Name));
                if (dbRegister == null) _dbContext.Disks.Add(item);
                else _dbContext.Update(dbRegister);
            }
            #endregion

            _dbContext.SaveChanges();
            Console.WriteLine("  LOADING FILES...");
            #region FILES
            var files = new List<File>();
            foreach (var item in disks)
            {
                var max = new Random().Next(100, 4000);
                for (int i = 0; i < max; i++)
                {
                    files.Add(
                        new File(
                            cameras.ElementAt(new Random().Next(1, cameras.Count)).Id,
                            item.Id,
                            $"20200920_1140_{i.ToString("0000")}_equipe",
                            "mp4",
                            $"E:/MEDIA/EQUIPE/20200920_1140_{i.ToString("0000")}_equipe.mp4",
                            "MEDIA",
                            DateTime.Now, 
                            new Random().Next(1024 * 1000, 1024*5000)));
                }
            }

            foreach (var item in files)
            {
                var dbRegister = _dbContext.Files.FirstOrDefault(_ => item.Name.Equals(item.Name));
                if (dbRegister == null) _dbContext.Files.Add(item);
                else _dbContext.Update(dbRegister);
            }
            #endregion

            _dbContext.SaveChanges();
        }

    }
}
