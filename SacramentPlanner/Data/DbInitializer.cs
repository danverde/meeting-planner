using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SacramentPlanner.Models;

namespace SacramentPlanner.Data
{
    public class DbInitializer
    {
        public static void Initialize(SacramentContext context)
        {
            if (context.SacramentPlan.Any())
            {
                return;
            }

            var plans = new SacramentPlan[]
            {
                new SacramentPlan { Date = DateTime.Parse("2018-09-12"), Conducting = "Bishop Thayne", OpeningHymn = "The Spirit of God",
                Invocation = "Brother Brown", SacramentHymn = "There is a Green Hill Far Away", IntermediateHymn = "Put Your Shoulder to the Wheel",
                ClosingHymn = "I am a Child of God", Benediction = "Sister Brown"},
                new SacramentPlan { Date = DateTime.Parse("2018-09-19"), Conducting = "Bishop Thayne", OpeningHymn = "Secret Prayer",
                Invocation = "Brother Orange", SacramentHymn = "I Stand All Amazed", ClosingHymn = "Once there was a Snowman", Benediction = "Sister Orange"}
            };

            foreach (SacramentPlan p in plans)
            {
                context.SacramentPlan.Add(p);
            }
            context.SaveChanges();

            var speakers = new Speaker[]
            {
                new Speaker { SacramentPlanID = plans.Single(c => c.Date == DateTime.Parse("2018-09-12")).SacramentPlanID, Name = "Brother Smith", Topic = "Charity"},
                new Speaker { SacramentPlanID = plans.Single(c => c.Date == DateTime.Parse("2018-09-12")).SacramentPlanID, Name = "Sister Smith", Topic = "Charity"},
                new Speaker { SacramentPlanID = plans.Single(c => c.Date == DateTime.Parse("2018-09-19")).SacramentPlanID, Name = "Sister Blue", Topic = "Faith"},
                new Speaker { SacramentPlanID = plans.Single(c => c.Date == DateTime.Parse("2018-09-19")).SacramentPlanID, Name = "Brother Jones", Topic = "Baptism"}
            };

            foreach (Speaker s in speakers)
            {
                context.Speaker.Add(s);
            }
            context.SaveChanges();
        }
    }
}
