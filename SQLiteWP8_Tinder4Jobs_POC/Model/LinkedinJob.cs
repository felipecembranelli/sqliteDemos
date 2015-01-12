using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWP8_Tinder4Jobs_POC.Model
{
    public class LinkedinJob
    {
        public LinkedinCompany Company { get; set; }

        public string DescriptionSnippet { get; set; }

        public string Id { get; set; }

        public LinkedinJobPoster JobPoster { get; set; }

        public string LocationDescription { get; set; }
    }

    public class LinkedinCompany
    {
        public string Id { get; set; }

        public string Name { get; set; }

    }

    public class LinkedinJobPoster
    {
        public string FirstName { get; set; }

        public string Headline { get; set; }

        public string Id { get; set; }

        public string LastName { get; set; }
    }

    public class JobList
    {
        public string Total { get; set; }

        public LinkedinJob[] Values { get; set; }

    }

    public class Facets
    {
        public string Total { get; set; }
    }

    public class LinkedinJobList
    {
        public Facets Facets { get; set; }

        public JobList Jobs { get; set; }

        public string NumResults { get; set; }

    }
}
