using Arztpraxis.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Arztpraxis.Client.Pages
{
    public partial class PersonenManagement
    {
        public PersonenManagement()
        {

        }

        public List<Person> Personen { get; set; }
    }
}
