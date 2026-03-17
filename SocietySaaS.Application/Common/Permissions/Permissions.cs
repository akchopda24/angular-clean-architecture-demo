namespace SocietySaaS.Application.Common.Permissions
{
    public static class Permissions
    {
        public static class Society
        {
            public const string View = "society.view";
            public const string Create = "society.create";
            public const string Update = "society.update";
            public const string Delete = "society.delete";
        }

        public static class Building
        {
            public const string View = "building.view";
            public const string Create = "building.create";
            public const string Update = "building.update";
            public const string Delete = "building.delete";
        }

        public static class Unit
        {
            public const string View = "unit.view";
            public const string Create = "unit.create";
            public const string Update = "unit.update";
            public const string Delete = "unit.delete";
        }

        public static class Resident
        {
            public const string View = "resident.view";
            public const string Create = "resident.create";
            public const string Update = "resident.update";
            public const string Delete = "resident.delete";
        }
    }
}