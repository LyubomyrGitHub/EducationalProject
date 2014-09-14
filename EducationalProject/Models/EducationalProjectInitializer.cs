﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EducationalProject.Models
{
    public class EducationalProjectInitializer: DropCreateDatabaseAlways<EducationalProjectContext>
    {
        protected override void Seed(EducationalProjectContext context)
        {
            var contacts = new List<Contact>
            {
                new Contact {Address = "7 Naukova St., Building G <br/> Lviv 79060, Ukraine", Fax = "+380 32 244-7002", Map = "", OfficeName = "ELEKS Global Headquarters</br>ELEKS, Ltd.", Phone1 = "+380 32 297-1251 ", Phone2 = "phone2"},
                new Contact {Address = "701 North Green Valley Pkwy</br>Suite 200</br>Henderson, NV 89074",Fax = "+1 678 905-9508", Map = "map", OfficeName = "US Offices</br>ELEKS, Inc. − Headquarters", Phone1 = "+1 866 588-0113 (toll-free US only)", Phone2 = "+1 617 600-4059"},
                new Contact {Address = "15 New England Executive Park</br>Burlington, MA 01803 ",Fax = "+1 678 905-9508", Map = "", OfficeName = "ELEKS, Inc. − Sales Office", Phone1 = "+1 866 588-0113 (toll-free US only)", Phone2 = "+1 617 600-4059"},
                new Contact {Address = "5 Harbour Exchange</br>South Quay</br>London, E14 9GE",Fax = "", Map = "", OfficeName = "UK Office</br>ELEKS Software UK, Ltd.", Phone1 = "+44 203 318-1274", Phone2 = ""},
                new Contact {Address = "Sales Representative</br>Montreal, Canada",Fax = "", Map = "", OfficeName = "ELEKS in Canada", Phone1 = "+14388000584", Phone2 = ""}
            };

            foreach (var contact in contacts)
            {
                context.Contacts.Add(contact);
            }

            context.SaveChanges();
        }
    }
}