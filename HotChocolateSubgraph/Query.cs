namespace HotChocolateSubgraph;

public class Query
{
    private static readonly Dictionary<int, DataRoom> DataRooms = new()
    {
        {
            0, new DataRoom
            {
                Id = 0,
                Name = "General Information",
                Folders = new[]
                {
                    new Folder
                    {
                        Name = "Company Overview",
                        Documents = new[]
                        {
                            new Document { Name = "Mission Statement" },
                            new Document { Name = "Company History" }
                        }
                    },
                    new Folder
                    {
                        Name = "Contact Information",
                        Documents = new[]
                        {
                            new Document { Name = "Employee Directory" },
                            new Document { Name = "Office Locations" }
                        }
                    }
                }
            }
        },
        {
            1, new DataRoom
            {
                Id = 1,
                Name = "Financial Reports",
                Folders = new[]
                {
                    new Folder
                    {
                        Name = "Quarterly Reports",
                        Documents = new[]
                        {
                            new Document { Name = "Q1 2024 Report" },
                            new Document { Name = "Q2 2024 Report" }
                        }
                    },
                    new Folder
                    {
                        Name = "Annual Reports",
                        Documents = new[]
                        {
                            new Document { Name = "2023 Annual Report" },
                            new Document { Name = "2022 Annual Report" },
                            new Document { Name = "2021 Annual Report" }
                        }
                    }
                }
            }
        },
        {
            2, new DataRoom
            {
                Id = 2,
                Name = "Project Documents",
                Folders = new[]
                {
                    new Folder
                    {
                        Name = "Project Alpha",
                        Documents = new[]
                        {
                            new Document { Name = "Project Alpha Proposal" },
                            new Document { Name = "Project Alpha Budget" }
                        }
                    },
                    new Folder
                    {
                        Name = "Project Beta",
                        Documents = new[]
                        {
                            new Document { Name = "Project Beta Proposal" },
                            new Document { Name = "Project Beta Timeline" }
                        }
                    }
                }
            }
        }
    };

    public List<DataRoom> GetDataRooms()
    {
        return DataRooms.Values.ToList();
    }
    
    public DataRoom GetDataRoom(int id)
    {
        return DataRooms[id];
    }
}