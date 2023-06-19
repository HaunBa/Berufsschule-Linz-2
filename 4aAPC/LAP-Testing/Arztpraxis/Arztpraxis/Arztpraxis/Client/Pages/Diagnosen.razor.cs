using Arztpraxis.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace Arztpraxis.Client.Pages
{
    public partial class Diagnosen
    {
        public Diagnosen()
        {

        }

        public List<Termin>? Termine { get; set; } = null;
        public int SVNR { get; set; } = 0;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool SVNRValid { get; set; } = true;
        public bool? StartDateValid { get; set; } = true;
        public bool? EndDateValid { get; set; } = true;

        async Task GetDiagnoses()
        {
            if (ValidateInputs())
            {
                Termine = await Http.GetFromJsonAsync<List<Termin>>($"api/Diagnose/{SVNR}/{StartDate}/{EndDate}") ?? new();
            }
        }

        private bool ValidateInputs()
        {
            // validate SVNR
            SVNRValid = SVNR.ToString().Length == 4;

            StartDateValid = !(StartDate > DateTime.Now) && !(StartDate > EndDate);

            EndDateValid = !(EndDate > DateTime.Now);

            return EndDateValid == true && StartDateValid == true && SVNRValid == true;
        }
    }
}
