namespace ProiectII.Migrations
{
    using ProiectII.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProiectII.Models.ShopDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProiectII.Models.ShopDBContext context)
        {
            var productsToDelete = context.Set<Product>();
            context.Products.RemoveRange(productsToDelete);

            var categoriesToDelete = context.Set<Category>();
            context.Categories.RemoveRange(categoriesToDelete);
            context.SaveChanges();

            context.Categories.AddOrUpdate(x => x.Id,
                new Category
                {
                    Name = "Telefoane",
                    Description = "Iti doresti un telefon mobil nou? Telefoanele mobile Livrate de eMAG au preturi avantajoase!",
                    Icon = "ceva"
                },
                new Category
                {
                    Name = "Electrocasnice",
                    Description = "Intra acum si afla noile oferte ale lunii! Profita acum!",
                    Icon = "ceva2"
                },
                new Category
                {
                    Name = "Fashion",
                    Description = "Alege-ti una din rochiile primaverii iar la o comanda minima de 200lei, transportul va fi gratiut!",
                    Icon = "ceva3"
                },
                new Category
                {
                    Name = "Sport",
                    Description = "Alege-ti accesoriile perfecte pentru activitatile tare preferate in aer liber!",
                    Icon = "ceva4"
                },
                new Category
                {
                    Name = "Jucarii",
                    Description = "Jucarii pentru copii",
                    Icon = "ceva5"
                }
            );
            context.SaveChanges();

            var databaseCategories = context.Categories.ToList();

            context.Products.AddOrUpdate(x => x.Id,
                 new Product { Category = context.Categories.FirstOrDefault(c => c.Name == "Telefoane"), Name = "Samsung Galaxy S10", Description = "Dual SIM, 512GB, 8GB RAM, 4G, Green", Image = "https://s13emagst.akamaized.net/products/20114/20113791/images/res_c8f1276fa0f35692ff77ec22a6fd1e6c.jpg?width=450&height=450&hash=E63F32EA2F84479AEA48317F76F548CB", Price = 2100, Stock = 23 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Telefoane"), Name = "Samsung Galaxy Fold", Description = "512GB, 12GB RAM, 4G, Cosmos Black", Image = "https://s13emagst.akamaized.net/products/27081/27080506/images/res_185d6828cbd26590ecc2be054ca96358.jpg?width=450&height=450&hash=57159BC24A3187C5B182D0652C691C48", Price = 1675, Stock = 100 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Telefoane"), Name = "Samsung Galaxy S20 FE", Description = "Dual SIM, 128GB, 6GB RAM, 5G, Cloud White", Image = "https://s13emagst.akamaized.net/products/32539/32538468/images/res_bd8e1c7176552702347fef6439040625.jpg?width=450&height=450&hash=3C6E673DDE9FCDC6C3AD4D20BAA04FAF", Price = 800, Stock = 58 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Telefoane"), Name = "Iphone 12 PRO MAX", Description = "256 GB,placat cu aur si piele de crocodil maro", Image = "https://s13emagst.akamaized.net/products/26256/26255413/images/res_2ad8a3a002658d47e1233715a830c18e.jpg?width=450&height=450&hash=6ADE7D01DA1F3D34A580E36A32707271", Price = 4250, Stock = 13 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Telefoane"), Name = "iPhone 11 Pro", Description = "64GB, Gold", Image = "https://s13emagst.akamaized.net/products/25344/25343967/images/res_714361af9d0b0b5e9aace27360a7699c.jpg?width=450&height=450&hash=CB276521D1F0F3A7A0CF3BEE87087B6F", Price = 1150, Stock = 68 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Telefoane"), Name = "iPhone 8", Description = "64GB, 4G, Space Grey", Image = "https://s13emagst.akamaized.net/products/8892/8891501/images/res_4bd85c5b3fe313d31097680ce4864e9e.jpg?width=450&height=450&hash=765B62141A5BFF0A87A93BD22F262760", Price = 600, Stock = 4 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Telefoane"), Name = "Huawei Mate XS", Description = "Dual SIM, 512GB, 8GB RAM, 5G, Interstellar Blue", Image = "https://s13emagst.akamaized.net/products/29635/29634810/images/res_370dba2278520bf24f292267cc86728d.jpg?width=450&height=450&hash=866F1C44AC7C8D405D2BEDACFB055732", Price = 2700, Stock = 35 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Telefoane"), Name = "Huawei Mate 20X", Description = "Dual SIM, 256GB, 8GB RAM, 5G, Emerald Green", Image = "https://s13emagst.akamaized.net/products/23409/23408936/images/res_7939836f74b16f08d2591ab64feb3fd1.jpg?width=450&height=450&hash=302CDA54E0668046B90DABF78FEC3415", Price = 1390, Stock = 40 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Telefoane"), Name = "Huawei Mate 20", Description = "Single SIM, 128GB, 4G, Black", Image = "https://s13emagst.akamaized.net/products/18531/18530385/images/res_49efd3dddd6566b58a0c45639cb438b1.jpg?width=450&height=450&hash=448F8D53B90059EFB12B4991DC8FB799", Price = 510, Stock = 33 },    
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Electrocasnice"), Name = "Frigider MIELE", Description = "KS 28463 D BB, 386 l, H 185 cm, Clasa A, Negru", Image = "https://s13emagst.akamaized.net/products/34546/34545161/images/res_375d7fd74c291b8a326dee03050d60ca.jpg?width=450&height=450&hash=36D2F6B9E6438733AD04D1A41BF372A6", Price = 3500, Stock =  25},
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Electrocasnice"), Name = "Frigider Toshiba", Description = "GR-RT820PGJ-XK, 608 l, NoFrost, Compresor inverter, Clasa A++, H 184 cm, Sticla neagra", Image = "https://s13emagst.akamaized.net/products/30434/30433545/images/res_0dc428e47fc95105bfd0bac15abca513.jpg?width=450&height=450&hash=7ADD60E4C6FC2FCEB3B29A57D5F89C42", Price = 1000, Stock = 15 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Electrocasnice"), Name = "Frigider incorporabil", Description = "Electrolux ERN2001BOW, 187 l, Clasa A+, H 122 cm, Usa reversibila, Congelator", Image = "https://s13emagst.akamaized.net/products/9712/9711881/images/res_038f9380785b353643d4a0b7f0c7f9cf.png?width=450&height=450&hash=6C7881C406F1D53DF855655ECB6D8F36", Price = 475, Stock = 55 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Electrocasnice"), Name = "Masina de spalat rufe Miele", Description = "WTZH730, Spalare 8 kg, Uscare 5 Kg, 1600 rpm, Clasa A, Alb", Image = "https://s13emagst.akamaized.net/products/5476/5475539/images/res_cf992ec40b6ad59f491a64270a00945c.jpg?width=450&height=450&hash=4BBD62314E96D338AACAF269BA2F42D7", Price = 2000, Stock = 77 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Electrocasnice"), Name = "Masina de spalat rufe HOTPOINT", Description = "AQD1072D 697 EU-B N, 10/7 kg, 1600rpm, Clasa A, Alb", Image = "https://s13emagst.akamaized.net/products/35165/35164652/images/res_be6dfcf6c00b952d53cc3cfb7870dfc9.jpg?width=450&height=450&hash=9903EDBC2CD957BAA2E8F2B78D039999", Price = 1000, Stock = 144 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Electrocasnice"), Name = "Masina de spalat rufe Candy Smart Pro", Description = "CSOW 4855TB, Spalare 8 kg, Uscare 5 kg, 1400 RPM, Clasa C, WiFi, Steam, Kilo Detector, Alb", Image = "https://s13emagst.akamaized.net/products/32502/32501487/images/res_b1fe46c39bfef80726d44c0acba03f75.jpg?width=450&height=450&hash=5763517C725BDD1560FF14C6E7CB4B7C", Price = 250, Stock = 175 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Electrocasnice"), Name = "Aragaz profesional", Description = "Moratti, 6 ochiuri 1200x900x850 mm", Image = "https://s13emagst.akamaized.net/products/18352/18351829/images/res_bbbc90957beee989293e62253aeac667.jpg?width=450&height=450&hash=B49CF0C5F039EE8564BF40F70C575470", Price = 4000, Stock = 155 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Electrocasnice"), Name = "Aragaz Bosch", Description = "HXN39BD504 arzatoare, Mixt, Aprindere electrica, Grill, Autocuratare EcoClean Direct, Display digital, Timer, Clasa A, 60 cm, Inox", Image = "https://s13emagst.akamaized.net/products/14872/14871143/images/res_73f45f6933845f7507f061886a204e40.jpg?width=450&height=450&hash=44EB8D0F4BEC132E1662509B9EBA84EE", Price = 500, Stock = 9 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Electrocasnice"), Name = "Aragaz Gorenje", Description = "EC62CLI, Cuptor electic, Plita vitroceramica cu 4 zone de gatit, Grill, 60 cm, Champagne", Image = "https://s13emagst.akamaized.net/products/13314/13313167/images/res_e4b214ad00c7bcff1f7324b0ce4e4f1d.jpg?width=450&height=450&hash=C36A325B71EB476466B5C939D2E74FBA", Price = 400, Stock = 3 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Fashion"), Name = "Rochie Vascoza", Description = "Alba Liza Panait RM-1E", Image = "https://s13emagst.akamaized.net/products/22493/22492718/images/res_efc0f53181f01ab6a2234d75e521365d.jpg?width=450&height=450&hash=9A10D1B868720CDC852C9B292693AC13", Price = 1100, Stock = 190 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Fashion"), Name = "Rochie Felba", Description = "Model Ama,culoarea rosu", Image = "https://s13emagst.akamaized.net/products/15313/15312228/images/res_42f9b6f13753f14f37d8df7da231c019.jpg?width=450&height=450&hash=6A53869D6495C12400C0C69F16F48725", Price = 800, Stock = 88 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Fashion"), Name = "Rochie Lunga", Description = "Eleganta de matase cu corset si pene, Elena Perseil", Image = "https://s13emagst.akamaized.net/products/30062/30061753/images/res_392716c3dd43caa470c077ee8d74a4d3.jpg?width=450&height=450&hash=6AB093442B0118DB3FDE3E09ACEF4DA5", Price = 650, Stock = 100 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Fashion"), Name = "Pantofi Jimmy Choo", Description = "Argintiu", Image = "https://s13emagst.akamaized.net/products/23237/23236851/images/res_f4cce597680bd5eb71c9dcc2a9e57eee.jpg?width=450&height=450&hash=B315D5D288FD35AEDFA0D131213E68F9", Price = 700, Stock = 55 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Fashion"), Name = "Pantofi", Description = "Philipp Plein", Image = "https://s13emagst.akamaized.net/products/33710/33709786/images/res_9d60600fb63cb17ece88b7a0f2c541a1.jpg?width=450&height=450&hash=AF7224C01E0EDEBA288A27CE8E0403D2", Price = 500, Stock = 17 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Fashion"), Name = "Pantofi Viorica del Prado", Description = "Queen's Crown, Roz", Image = "https://s13emagst.akamaized.net/products/33155/33154021/images/res_ca065ec35970abc4555dd2f8b0f8df91.jpg?width=450&height=450&hash=1728404E76D543526418E5CC002DD5A9", Price = 300, Stock = 33 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Fashion"), Name = "Colier", Description = "Diamante naturale", Image = "https://s13emagst.akamaized.net/products/32056/32055751/images/res_17ba9549f65ded1a036217c8410bd112.jpg?width=450&height=450&hash=82F3783DA71FE07E834D65A8CB5378B1", Price = 7500, Stock = 5 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Fashion"), Name = "Colier Swarovski", Description = "Flower heart cu cristale albastru", Image = "https://s13emagst.akamaized.net/products/32479/32478148/images/res_87c13ef57156c7544766f1ec5697cd4b.jpg?width=450&height=450&hash=86676337C06B14848022483A1B184BF1", Price = 7000, Stock = 80 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Fashion"), Name = "Colier Swarovski-Alabaster", Description = "Angels Hand made cu cristale Crystal", Image = "https://s13emagst.akamaized.net/products/32807/32806341/images/res_c397f3ff9ef0015e32ecd958b927630a.jpg?width=450&height=450&hash=F30E6CE66C745AB7202237EAB8BE48A0", Price = 5000, Stock = 12 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Sport"), Name = "Ceas Garmin Fenix 6S", Description = "Sapphire Carbon Grey DLC, Black Band", Image = "https://s13emagst.akamaized.net/products/33185/33184733/images/res_5fdd818aed8768eb4e2e531bef1c80e8.jpg?width=450&height=450&hash=5FC4214E671E70364220AD478E453F16", Price = 1100, Stock = 10 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Sport"), Name = "Ceas Garmin", Description = "Forerunner 945", Image = "https://s13emagst.akamaized.net/products/33443/33442083/images/res_7fa45f18b49833fc3e7c30945eedfb66.jpg?width=450&height=450&hash=3DF2E6A9B4FC4276BBC587F6419601BB", Price = 700, Stock = 8 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Sport"), Name = "Ceas Garmin Forerunner", Description = "245 Black Slate", Image = "https://s13emagst.akamaized.net/products/33318/33317287/images/res_a031e92732b31a3bc53183e568c9a15b.jpg?width=450&height=450&hash=4BDCA71C79422131C298832B5C51EB68", Price = 450, Stock = 28 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Sport"), Name = "Minge Adidas", Description = "Tsubasa FR8367, marimea 5, Fifa QualityPro", Image = "https://s13emagst.akamaized.net/products/31761/31760099/images/res_ab330b6d5983b78a92beae8798f2ec19.jpg?width=450&height=450&hash=04986DFAF8E1B635915DAD530AB65059", Price = 200, Stock = 50 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Sport"), Name = "Minge Molten B6G4500", Description = "aprobata FIBA, marime 6", Image = "https://s13emagst.akamaized.net/products/28924/28923618/images/res_ee3fe7f14fb9606725af53e135db0d83.jpg?width=450&height=450&hash=1F785CD7CFEAEE33CEA6ED34C099F421", Price = 100, Stock = 90 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Sport"), Name = "Minge", Description = "Molten V5M4500", Image = "https://s13emagst.akamaized.net/products/10679/10678163/images/res_9c30051578248a184d9fd2e08842d381.jpg?width=450&height=450&hash=4187CAFB35D7DC4F161285B250B0FC94", Price = 50, Stock = 88 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Sport"), Name = "Ochelari de soare", Description = "Wiley X GravityLentile polarizate verzi Captivate", Image = "https://s13emagst.akamaized.net/products/31107/31106820/images/res_9d6f1a05d196828f256b8266d5f9c9e8.jpg?width=450&height=450&hash=3C9DD650095C513F93101F345A4E2F41", Price = 250, Stock = 55 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Sport"), Name = "Ochelari Alpina", Description = "Twist Five Qwm+, Negru Mat", Image = "https://s13emagst.akamaized.net/products/22732/22731163/images/res_8c3212f4d7e238a4c8fea46c7f1a42d7.jpg?width=450&height=450&hash=8B5FC7A5A062DF6635A2A70ADE40A13D", Price = 200, Stock = 4 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Sport"), Name = "Ochelari inot", Description = "Speedo Vue Mirror", Image = "https://s13emagst.akamaized.net/products/28886/28885459/images/res_ae5f24ec995626b01c899c749d8da2b2.jpg?width=450&height=450&hash=F22B4C8B88787074BAAE5C9F45CD4603", Price = 100, Stock = 66 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Jucarii"), Name = "Papusa Barbie", Description = "Gold Label editia Star Wars C-3PO", Image = "https://s13emagst.akamaized.net/products/35073/35072946/images/res_ae30f41ff8f0b93b431b0f0951ef39fa.jpg?width=450&height=450&hash=A751547DC1881FC753F260BEF15E10EE", Price = 200, Stock = 78 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Jucarii"), Name = "Papusa Paola Reina", Description = "Cu rochie lunga de seara roz prafos", Image = "https://s13emagst.akamaized.net/products/29758/29757292/images/res_6aec198a2e2f04b4818b8b7cf973fd27.jpg?width=450&height=450&hash=0669ECA99B5853E2A38CADBCF4CF1101", Price = 65, Stock = 22 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Jucarii"), Name = "Papusa", Description = "In rochie roz", Image = "https://s13emagst.akamaized.net/products/35636/35635990/images/res_97049a7993d85a82e4f4c9d8e6d2eb09.jpg?width=450&height=450&hash=1766A0A5D7F640D55DCBEBEC4C396499", Price = 7, Stock = 33 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Jucarii"), Name = "Masina cu telecomanda JLB", Description = "Racing Cheetah 11101 80A RTR 4x4", Image = "https://s13emagst.akamaized.net/products/33003/33002965/images/res_9504a505f6fbafda7d7d1cfcc8775e4c.jpg?width=450&height=450&hash=147BF488257E4DC9EF94D4EF1FD1B3F3", Price = 500, Stock = 25 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Jucarii"), Name = "Masinuta cu telecomanda Twist", Description = "Shoot Maisto", Image = "https://s13emagst.akamaized.net/products/31882/31881607/images/res_402d942bc00503ef2b9733e36f9cfc0b.jpg?width=450&height=450&hash=ABD55768FAB7B37781F1938BEA17FA83", Price = 150, Stock = 45 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Jucarii"), Name = "Masinuta cu Telecomanda iUni 2168A", Description = "20km/h Off Road Climbing", Image = "https://s13emagst.akamaized.net/products/30893/30892025/images/res_7a3fbce7f4ad8b9cad2d8f62a8a6f357.jpg?width=450&height=450&hash=BDDD4E1DA8CAF2948E8B69C48929AC00", Price = 100, Stock = 31 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Jucarii"), Name = "LEGO Star Wars", Description = "Super Star Destroyer", Image = "https://s13emagst.akamaized.net/products/734/733998/images/res_e74e9e57669fa54005955901adad4390.jpg?width=450&height=450&hash=231A7B897F80DAA858B456594F7D1AE6", Price = 2150, Stock = 6 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Jucarii"), Name = "LEGO Marvel", Description = "Super Heroes ", Image = "https://s13emagst.akamaized.net/products/3634/3633870/images/res_23686249509717c80c531ab497477b7d.jpg?width=450&height=450&hash=B1E748A38B8AAD1F619F28857987C77F", Price = 450, Stock = 20 },
                 new Product { Category = databaseCategories.FirstOrDefault(c => c.Name == "Jucarii"), Name = "LEGO Creator", Description = "Expert - Old Trafford", Image = "https://s13emagst.akamaized.net/products/30004/30003507/images/res_9eea604f813ca9a09e03e6d5c20e7f2d.jpg?width=450&height=450&hash=F4F4E805B0806BA0C37B3AE940C56249", Price = 250, Stock = 15 }
            );

        }
    }
}