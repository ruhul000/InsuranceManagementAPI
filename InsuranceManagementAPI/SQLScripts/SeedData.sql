USE [Policy]
GO

-- Users
SET IDENTITY_INSERT [dbo].[Users] ON 
INSERT [dbo].[Users] ([UserId], [FullName], [UserName], [Email], [Password], [Salt], [IsActive]) VALUES (1, N'Ruhul Amin', N'ruhul', N'euhul.ewu00@gmail.com', N'0IbQDMZFPTPjktZ7+tkiEvzokjn7DWojrD9vynaUn0zcibd8ufsjMSYYOMaMAe2OF5Ro1dTJSBU+qZxi+V5aDGdaVzMcdwwgekVGe7nl8Bfi58M/+1yNYSWRmMB6gF27PvOYGEBh/1gGHXEpb6M4xFtC4I18xd8tfOXccFJhNa2OabDhq2Tnjnl6OfnGVP1ycJs1EF6L2wsbKxEYjic3iItdNiEA9Xv1bMTVCf0oNGf8AvsUDokotACagVEBmmzGqmRjn9bcrC4izFS+Y0JH9/TdO+CkBeANOxaQ1AE/4h5cWWo1pZRskHQ89bocv7Xwoi9aPzhJhBZykabPdSRfDw==', N'RXjpkbcqtDVlGI7zzYlw2/sTTqiIeZEkL5PERGn0jA8rwr8bXq14baVFwlrwG4t06KK3SgU9DtepSKHrao9fX4SDkK51IY6+E9aMtNXuaaNmkTHAtdwgXU/q9xeso18WqsJb8NhjJWLQYK+yBbJjMvnPw19HjF6zsy0GN/7gdjc=', 1)
INSERT [dbo].[Users] ([UserId], [FullName], [UserName], [Email], [Password], [Salt], [IsActive]) VALUES (2, N'Omar Faruk', N'mohon', N'mohon.sust@gmail.com', N'12rZ+oWz3lVOsvVPsL9y3/3fJ+gfS6CdjtR1dLNxc6HapBG+HTyj0HWgSYL9vpl04amf7YEGUmJw7p/40Hki+yqhRouI4J5mcSkvhevMhEbJGtGI2L4IeA2tbhQDc7Ufwiz0LmB66JOP7Mivw0wQcF3SCAN/oyw0V78GDwFfOBWSaZJYt2FB6UAUlTgI7WDNSzQIKvl3kjkJkosj8gQZ9Y6rXr99docJ0bpdTPMu8PWErATNK6C9arlhuYJHm0Xn0anN5wZ6eQuQwCRihoitcY3LOupSCt6adO/GpPejGhhIfJDewRSy3LKNbkjKDO179r5mVKYsqgql0E/DfvK1vg==', N'Qkn/BGsYypxt0hpjZy2dYYhJt4S5Zr5nasjDOUx966Wngr4G1bisnIJE0M4stFUkyXdcvZ0asHAUd+hQxumWnl0QBjIz5bPf5ETn/nJuKCbjje8MVjYLaZw8+UUfXBtrZF9R+btVetskMVULcm7ZuWRD6aiqdIgfyXGTgMZf+jU=', 1)
INSERT [dbo].[Users] ([UserId], [FullName], [UserName], [Email], [Password], [Salt], [IsActive]) VALUES (3, N'Amit Bhuiyan', N'amit', N'amit@gmail.com', N'SAHsslQ+VDpk7vGB4eJwJV1qDVmANQmgGkYju/fmht0N+r+uaAy7sSVnTBV+Yj6CeeNOsaPUP5G4nepF4MyiiexlG3PNkwd+uWkkFvCE0Kc6q4V/4bR2wr5CggvXCsPJHWpxH1EhTiGGLzcWk9v8cFat+KIs9dAEMoZ4cCazu+hdL0WkfjoPK0/xnU/sz0zTYNtRV4OdePLy0qRKuCbJ5PQfyRkx4wnNfp+hVXMVTRLxiAs8Z49UY93XlqyNEaSUJM2ycNlRk/z/yLMN4V+IoswMSSyGIPSjaD9LOZ4zA0qpxXiUZJjBRkJ8z77Qcpl+Sgu+Wnxg8AEvFxuk6kJhgg==', N'eVv0GDffN6r1jXaVhopcrZiQnznsevjUWYS46lN6G1NdEqFyM46VEOQD/NFi0lORfcICQDxctnAQAGTfenoSMbIDidd0lj7Yxb+CU5ZW5qkV4ZRWGXrxF06+xgJXb3/DQ5cS/WYjyNwy1kwATIK0OaZaElevEu5wJG4QpSJEh60=', 1)
INSERT [dbo].[Users] ([UserId], [FullName], [UserName], [Email], [Password], [Salt], [IsActive]) VALUES (4, N'Kaniz Fima', N'fima', N'fima@gmail.com', N'Laigh25pb+ycXkly7B+x6M1E5dD1HCOgTsEfsmc1aR43np0FHLmjlVgCWM9+L2c4/dbc92dErXubghJ6wqSOk53WaZYLlJWleak0Dgw8V0wW7MWM09UAjyDV5ruDTKtbCSgpa0V+S3Nj2g/LBLDYGbz6oIwd1XpyUMS+u+kVWa+VRbywJpryveHo2IDwfgytLmsbYjstst74II1UnDi8xmHjOSuZ+8tO2EIAUwkvRm7RU6labiRfoWFULtS+tOHMa7OvRhB45drQ4hh+MDbULKmFi7muDF+beJPOj0f0/dlsmdnqGBruO/ase/fnzVDso5AtggCWYf4A04XOZ+LJLw==', N'QiE627VdP6EhKVZw9P4iutJH+Cm8XSCiv0FWvWpAtArC6ZNIKe7cuIajurE86bnBJfUSFoK0ZkQD5xiSw2QLGjsqaf86ky2zpnaXubvPXNiw9azW7JGUWblvswqJHrQX0Ld5oUZ5+KIAWNi2QRiWddgWQyDvGaNtCzQOpS59kzQ=', 1)
INSERT [dbo].[Users] ([UserId], [FullName], [UserName], [Email], [Password], [Salt], [IsActive]) VALUES (5, N'string', N'string', N'string', N'klvj9OqbG0FMsLWe/alSq5Ycn/v1WVVLziGQmZXbwMLxskOkNfQRwiOc8hvbsb84c0BO9CmYeLvaqhMCltYXOsra8VzGOfY4XuyCdPD36BTzp1uRrjRDTfD9NqDSg/YnQabAluCBvlnv7URV3Z5ZhVALYkcIwbYvZr/s2PVva1K+g0iVFoSbFEV5L0HC3PdDbT8a/5hV9kueIJwf0d4bPn5Vbs3U6YiHNSnLdBbS1yBNuDF7nQOZyC9ZEVU5zrXRpKgChqIza981Vfo6V8QQ1Wxl1iZND8mSmM3tzFDEXqYkmQC9dPDdoeqSR1cbqfi69yunc0LzhxGBUyuHJdvfiQ==', N'oSu7I3UxFhBFNl+Jaao4VP+lD7GwGiDny9yP96m70pum+rRfGdFweRaCw3aITOnc8TKnXeH2e41tFtoiccqKV7zdYEF9/tDIlxaP9yQAbw36420jEehvPK/5pL4hCVPeRKsd8l1V8pcjN3zy0gw4juDrw3vY7s1yavkHmhIHJF8=', 1)
INSERT [dbo].[Users] ([UserId], [FullName], [UserName], [Email], [Password], [Salt], [IsActive]) VALUES (6, N'Kaniz Fima', N'kaniz', N'kaniz@gmail.com', N'geDb3tvfPoX0K9O1OX6mQvztLmEzWbvzFX5KcetdPiPMNQXdWuru1RKDwsmFt5iqmPcGhLHk8YikZVGodGaNrYSYF4aiB6bl4NcRXTvMo2X4B4FK+4HbLM+3Hpr722oBl1oK/iAkcU0vG5HhaRxJ9Z6iO+DzRYsQ7ogZSI3F6u60ksVhJWVnhv0JNuyYI+DT0TQ8UD8bVMi7WYJHzEliYGgpxKI4IDTubnVoX/FMy6KAEcOD6icanjlvIyU6E3/oScrd7iEr5RUBExIHNx6VvT/TuAEt85+KuB1V9HCTiGoLGyNTAjNRBzO8nAtD4rCopT1WEoTVTGpyqjl4IgjM6Q==', N'+f8tEtIRjvWVESPnafZw3OZJt3a/izoHNTv0gMNAAUIhyQJAss9KRANQcnzWyBGJzWHvqg/3kbPCvVjkxvsIf7qdfh07QPUMMIIy5347T+imnzeH+ZLxH2PQpNFuU2GvNVUFfjGgOh5duSMfiCBg9V9i6h1+spWs6UT8zQYKb9k=', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF

-- RefreshToken
INSERT [dbo].[RefreshToken] ([UserName], [TokenID], [RefreshToken], [IsActive]) VALUES (N'ruhul', N'1629124971', N'qSe9lAhwV3/VSF20CqsoQPl1Y33GwqDiRwrIbMd/JQ8=', 1)
INSERT [dbo].[RefreshToken] ([UserName], [TokenID], [RefreshToken], [IsActive]) VALUES (N'string', N'2134730658', N'7aDiMr1pF1nvBYdcJrVXgY6wtADrsp/kTlLXVaWp5J0=', 1)

-- Bank
SET IDENTITY_INSERT [dbo].[Bank] ON 
INSERT [dbo].[Bank] ([BankId], [BankName]) VALUES (1, N'The City Bank')
INSERT [dbo].[Bank] ([BankId], [BankName]) VALUES (2, N'Pubali Bank')
SET IDENTITY_INSERT [dbo].[Bank] OFF

-- tab_Client
SET IDENTITY_INSERT [dbo].[tab_Client] ON 
INSERT [dbo].[tab_Client] ([ClientKey], [BranchKey], [ClientName], [ClientNameExtar], [ClientAddress], [ClientMobile], [ClientType], [ClientTypeTwo], [ClientSector], [ClientVATNo], [ClientBINNo], [ClientTINNo], [Client_VAT_Exemption], [GroupKey], [ClientPhone], [ClientFax], [ClientEMail], [ClientRelation], [ClientWeb], [ClientContractPer], [ClientDesignation], [SpecDiscount], [EmpKeyDirectorRef], [Status], [Int_A], [Int_B], [Int_C], [Int_D], [Str_A], [Str_B], [Str_C], [Str_D], [Date_A], [Date_B], [Date_C], [BackupType]) VALUES (1, 1, N'Nurul Amin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tab_Client] OFF


