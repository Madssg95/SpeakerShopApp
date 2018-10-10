using System;
using SpeakerShopApp.Core.Entity;

namespace SpeakerShopApp.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB (SpeakerShopAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();


            var bose = ctx.Brands.Add(new Brand()
            {
                SpeakerBrand = "Bose"
            }).Entity;

            var jbl = ctx.Brands.Add(new Brand()
            {
                SpeakerBrand = "JBL"
            }).Entity;

            var BangOgOlufsen = ctx.Brands.Add(new Brand()
            {
                SpeakerBrand = "B&O"
            }).Entity;

            var Sonos = ctx.Brands.Add(new Brand()
            {
                SpeakerBrand = "Sonos"
            }).Entity;


            var speaker1 = ctx.Speakers.Add(new Speaker()
            {
                SpeakerName = "Bose Soundbar",
                SpeakerDescription = "Test",
                Color = "Sort",
                Price = 2123,
                SpeakerBrand = bose,
                Url = "test"
            }).Entity;

            var speaker2 = ctx.Speakers.Add(new Speaker()
            {
                SpeakerName = "Bose Soundbar bla bla",
                SpeakerDescription = "Testt",
                Color = "Sort",
                Price = 2123,
                SpeakerBrand = jbl,
                Url = "test"
            }).Entity;

            var speaker3 = ctx.Speakers.Add(new Speaker()
            {
                SpeakerName = "Bose Soundbar bla bla",
                SpeakerDescription = "Testtt",
                Color = "Sort",
                Price = 9999,
                SpeakerBrand = BangOgOlufsen,
                Url = "test"
            }).Entity;

            var speaker4 = ctx.Speakers.Add(new Speaker()
            {
                SpeakerName = "Bose Soundbar bla bla",
                SpeakerDescription = "Testtt",
                Color = "Sort",
                Price = 123123,
                SpeakerBrand = Sonos,
                Url = "test"
            }).Entity;

            ctx.SaveChanges();

          
        }
    }
}
