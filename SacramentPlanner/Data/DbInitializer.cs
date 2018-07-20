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
                new Speaker { Name = "Brother Smith", Topic = "Charity"},
                new Speaker { Name = "Sister Smith", Topic = "Charity"},
                new Speaker { Name = "Sister Blue", Topic = "Faith"},
                new Speaker { Name = "Brother Jones", Topic = "Baptism"}
            };

            foreach (Speaker s in speakers)
            {
                context.Speaker.Add(s);
            }
            context.SaveChanges();

            var SacramentPlanSpeakers = new SpeakerAssignment[]
            {
                new SpeakerAssignment {
                SacramentPlanID = 1,
                SpeakerID = 1
                },
                new SpeakerAssignment {
                SacramentPlanID = 1,
                SpeakerID = 2
                },
                new SpeakerAssignment {
                SacramentPlanID = 2,
                SpeakerID = 3
                },
                new SpeakerAssignment {
                SacramentPlanID = 3,
                SpeakerID = 4
                },
            };

            foreach (SpeakerAssignment si in SacramentPlanSpeakers)
            {
                context.SpeakerAssignment.Add(si);
            }
            context.SaveChanges();
        }
    }
}
