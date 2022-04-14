using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.Utils
{
    public class Structure
    {
        internal class SearchType
        {
            public const string Organization = "Организация";
            public const string Nationality = "Национальность";
            public const string FIO = "ФИО";
            public const string Citizenship = "Гражданство";
        }
        internal class AuthEventError
        {
            public const int PROFILE_WRONG_AUTH = 0;
            public const int PROFILE_BLOCKED = 1;
            public const int PROFILE_SID_ERROR = 2;
            public const int PROFILE_MANY_ATTEMPTS = 3;
            public const int PROFILE_SUCCESS = 4;
        }
    }
}
