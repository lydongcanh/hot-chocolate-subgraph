namespace HotChocolateSubgraph;

public class Query
{
    public List<DataRoom> GetDataRooms()
    {
        return new List<DataRoom>
        {
            new()
            {
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
            },
            new()
            {
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
        };
    }
}