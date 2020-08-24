﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotnet5.GraphQL.Store.Repositories.Migrations
{
    public partial class Firstmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "ProductTypes",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>("nvarchar(max)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_ProductTypes", x => x.Id); });

            migrationBuilder.CreateTable(
                "Products",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Description = table.Column<string>("nvarchar(300)", maxLength: 300, nullable: true),
                    IntroduceAt = table.Column<DateTimeOffset>("datetimeoffset", nullable: false),
                    Name = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    Option = table.Column<string>("nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<decimal>("decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ProductTypeId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    Rating = table.Column<int>("int", nullable: false),
                    Stock = table.Column<int>("int", nullable: false),
                    Discriminator = table.Column<string>("nvarchar(30)", maxLength: 30, nullable: false),
                    BackpackType = table.Column<string>("nvarchar(max)", nullable: true),
                    BootType = table.Column<string>("nvarchar(max)", nullable: true),
                    Size = table.Column<int>("int", nullable: true),
                    AmountOfPerson = table.Column<int>("int", nullable: true),
                    KayakType = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        "FK_Products_ProductTypes_ProductTypeId",
                        x => x.ProductTypeId,
                        "ProductTypes",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Reviews",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Comment = table.Column<string>("nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Title = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        "FK_Reviews_Products_ProductId",
                        x => x.ProductId,
                        "Products",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                "ProductTypes",
                new[] {"Id", "Discriminator"},
                new object[] {new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), "TypeOne"});

            migrationBuilder.InsertData(
                "ProductTypes",
                new[] {"Id", "Discriminator"},
                new object[] {new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), "TypeThree"});

            migrationBuilder.InsertData(
                "ProductTypes",
                new[] {"Id", "Discriminator"},
                new object[] {new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), "TypeTwo"});

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("897e109d-f017-4823-9216-b38ae0ced709"),
                        "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 4, 16, 1, 42, 27, 329, DateTimeKind.Unspecified).AddTicks(3837),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Rustic Granite Computer", "One", "https://picsum.photos/640/480/?image=242", 651.26m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 0, 670, "Hiking"
                    },
                    {
                        new Guid("1e67be09-26ec-434d-bd4a-90588d726363"),
                        "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 4, 13, 4, 57, 9, 313, DateTimeKind.Unspecified).AddTicks(9385),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Handcrafted Soft Chicken", "Two", "https://picsum.photos/640/480/?image=995", 78.55m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 9, 440, "Cycling"
                    },
                    {
                        new Guid("945f9679-5d2f-425f-958e-37195231b400"),
                        "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 3, 18, 5, 0, 52, 613, DateTimeKind.Unspecified).AddTicks(5621),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Practical Plastic Sausages", "Two", "https://picsum.photos/640/480/?image=657", 573.17m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 1, 1737, "Snowsports"
                    },
                    {
                        new Guid("23c56966-d859-4234-a5f1-16c1cf5a0f66"), "The Football Is Good For Training And Recreational Purposes",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 5, 11, 20, 57, 47, 743, DateTimeKind.Unspecified).AddTicks(2418),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Sleek Frozen Sausages", "Two", "https://picsum.photos/640/480/?image=208", 158.28m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 1, 3219, "Snowsports"
                    },
                    {
                        new Guid("0d916615-c108-438d-9769-a1bbdf1558df"),
                        "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 3, 30, 20, 23, 51, 645, DateTimeKind.Unspecified).AddTicks(202),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Rustic Wooden Table", "One", "https://picsum.photos/640/480/?image=458", 351.77m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 8, 213, "Snowsports"
                    },
                    {
                        new Guid("1c2d8a2e-7ce5-4dae-adca-59bc2ec1ef2e"),
                        "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 6, 26, 20, 52, 15, 159, DateTimeKind.Unspecified).AddTicks(7848),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Awesome Granite Pants", "One", "https://picsum.photos/640/480/?image=748", 147.67m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 8, 2100, "Climbing"
                    },
                    {
                        new Guid("76daf81c-3401-49fa-8d8f-dd28082ad75e"),
                        "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 10, 14, 7, 40, 24, 862, DateTimeKind.Unspecified).AddTicks(8562),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Refined Plastic Shoes", "One", "https://picsum.photos/640/480/?image=167", 135.31m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 5, 3665, "Climbing"
                    },
                    {
                        new Guid("6a2ba0b2-7344-4164-8b41-c8477739ce18"), "The Football Is Good For Training And Recreational Purposes",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 6, 22, 4, 55, 55, 772, DateTimeKind.Unspecified).AddTicks(7487),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Rustic Steel Fish", "Two", "https://picsum.photos/640/480/?image=701", 866.39m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 6, 3226, "Cycling"
                    },
                    {
                        new Guid("a66edcbd-3f2d-4fc4-bec1-9b781e617602"),
                        "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 11, 6, 5, 25, 16, 585, DateTimeKind.Unspecified).AddTicks(7460),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Rustic Metal Chair", "Three", "https://picsum.photos/640/480/?image=750", 37.22m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 2, 233, "Overnight"
                    },
                    {
                        new Guid("939d2a92-79b3-45f3-bc93-b6dd3961eadb"),
                        "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 11, 26, 7, 3, 39, 731, DateTimeKind.Unspecified).AddTicks(9774),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Practical Rubber Shirt", "One", "https://picsum.photos/640/480/?image=352", 933.32m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 8, 2853, "Climbing"
                    },
                    {
                        new Guid("615c0cd9-0114-4b27-a61f-33b45ffa2a66"),
                        "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 12, 27, 20, 14, 44, 643, DateTimeKind.Unspecified).AddTicks(2783),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Small Soft Pants", "Three", "https://picsum.photos/640/480/?image=886", 975.21m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 7, 2468, "Climbing"
                    },
                    {
                        new Guid("701bacf8-9a38-46c2-9a2d-2a518d02608f"),
                        "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 1, 27, 3, 23, 48, 432, DateTimeKind.Unspecified).AddTicks(6521),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Sleek Granite Keyboard", "Three", "https://picsum.photos/640/480/?image=734", 466.12m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 5, 3009, "Hiking"
                    },
                    {
                        new Guid("0906f966-515b-4598-9626-04803c8c7fd2"),
                        "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 7, 22, 10, 29, 57, 413, DateTimeKind.Unspecified).AddTicks(5949),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Sleek Soft Chicken", "Two", "https://picsum.photos/640/480/?image=864", 947.74m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 5, 893, "Overnight"
                    },
                    {
                        new Guid("a5a283ae-9490-4891-8924-bd62f4379802"),
                        "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 10, 26, 13, 53, 19, 276, DateTimeKind.Unspecified).AddTicks(9448),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Ergonomic Fresh Keyboard", "Three", "https://picsum.photos/640/480/?image=802", 308.42m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 5, 714, "Hiking"
                    }
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "BootType", "Size"
                },
                new object[]
                {
                    new Guid("e322f0c1-cbf5-489c-9db3-743c90f2e379"),
                    "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                    "Boot",
                    new DateTimeOffset(new DateTime(2020, 10, 9, 18, 24, 41, 321, DateTimeKind.Unspecified).AddTicks(279),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "Awesome Steel Hat", "Two", "https://picsum.photos/640/480/?image=383", 599.13m,
                    new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 0, 1043, "Football", 20
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[]
                {
                    new Guid("438ac187-2627-4547-a76f-474ceb07e384"),
                    "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Backpack",
                    new DateTimeOffset(new DateTime(2020, 8, 26, 1, 24, 25, 168, DateTimeKind.Unspecified).AddTicks(8164),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "Generic Wooden Cheese", "Three", "https://picsum.photos/640/480/?image=985", 497.22m,
                    new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 10, 3421, "Snowsports"
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("33596881-adb1-4000-bc6b-21004ca9c071"),
                        "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 6, 14, 14, 19, 23, 309, DateTimeKind.Unspecified).AddTicks(2364),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Rustic Wooden Soap", "Three", "https://picsum.photos/640/480/?image=618", 573.09m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 3, 2857, 2, "Diving"
                    },
                    {
                        new Guid("6718ca7c-4c47-4510-ad6b-4aef71a291ac"),
                        "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 10, 1, 10, 55, 47, 665, DateTimeKind.Unspecified).AddTicks(439),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Generic Concrete Fish", "One", "https://picsum.photos/640/480/?image=817", 502.66m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 4, 798, 2, "Family"
                    },
                    {
                        new Guid("3df2271a-34bd-463d-8f59-e5ac425931eb"),
                        "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 8, 11, 2, 45, 30, 599, DateTimeKind.Unspecified).AddTicks(9412),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Awesome Granite Computer", "One", "https://picsum.photos/640/480/?image=699", 847.26m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 6, 28, 2, "Fishing"
                    }
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "BootType", "Size"
                },
                new object[,]
                {
                    {
                        new Guid("43330c72-7a2e-4f68-a3bf-9033adab7e11"),
                        "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 9, 2, 2, 3, 41, 100, DateTimeKind.Unspecified).AddTicks(4990),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Awesome Granite Shirt", "One", "https://picsum.photos/640/480/?image=704", 601.04m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 10, 1968, "Drysuit", 29
                    },
                    {
                        new Guid("9a29de42-e945-40fc-a8fe-10af4c561979"),
                        "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 3, 12, 13, 24, 1, 600, DateTimeKind.Unspecified).AddTicks(2683),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Tasty Wooden Shoes", "One", "https://picsum.photos/640/480/?image=530", 15.51m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 0, 476, "Harness", 22
                    }
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("764bcd23-7233-4bb2-9f03-5537da928654"),
                        "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 2, 16, 7, 23, 31, 134, DateTimeKind.Unspecified).AddTicks(5844),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Intelligent Cotton Pizza", "Two", "https://picsum.photos/640/480/?image=474", 352.77m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 2, 463, 2, "Family"
                    },
                    {
                        new Guid("bae3d8d9-4ef0-4b96-80ea-5b6f97c3592d"),
                        "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 12, 13, 17, 43, 27, 284, DateTimeKind.Unspecified).AddTicks(3036),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Incredible Metal Cheese", "One", "https://picsum.photos/640/480/?image=401", 812.52m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 0, 4413, 1, "Diving"
                    },
                    {
                        new Guid("8632f7b6-e753-4ffd-874b-803458ca9f8a"),
                        "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Kayak",
                        new DateTimeOffset(new DateTime(2021, 6, 4, 7, 10, 35, 543, DateTimeKind.Unspecified).AddTicks(7384),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Tasty Rubber Fish", "Three", "https://picsum.photos/640/480/?image=620", 280.02m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 6, 4103, 3, "Camping"
                    },
                    {
                        new Guid("98bb0c44-37eb-47d0-a223-425cd5efd6ff"),
                        "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 9, 15, 9, 25, 8, 709, DateTimeKind.Unspecified).AddTicks(1394),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Licensed Rubber Cheese", "One", "https://picsum.photos/640/480/?image=402", 721.46m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 5, 261, 1, "Family"
                    },
                    {
                        new Guid("7e609fbb-7592-4402-9181-61c801267efc"),
                        "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 10, 14, 22, 13, 45, 274, DateTimeKind.Unspecified).AddTicks(4467),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Refined Cotton Soap", "Three", "https://picsum.photos/640/480/?image=904", 346.05m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 5, 3743, 1, "Racing"
                    },
                    {
                        new Guid("17735443-1d03-4c4d-aacc-c8e190037f25"),
                        "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 8, 9, 7, 18, 11, 758, DateTimeKind.Unspecified).AddTicks(820),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Handcrafted Plastic Salad", "Three", "https://picsum.photos/640/480/?image=589", 164.59m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 9, 3603, 2, "Diving"
                    },
                    {
                        new Guid("47147942-4e54-4b64-8b84-23b0eed58e8d"),
                        "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 9, 2, 22, 20, 24, 199, DateTimeKind.Unspecified).AddTicks(8489),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Refined Granite Car", "Three", "https://picsum.photos/640/480/?image=133", 911.69m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 6, 1524, 1, "Family"
                    },
                    {
                        new Guid("3ce24034-d8f9-4da8-8177-7a0a383638d8"),
                        "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 12, 6, 17, 15, 50, 642, DateTimeKind.Unspecified).AddTicks(5663),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Unbranded Fresh Keyboard", "Three", "https://picsum.photos/640/480/?image=46", 102.44m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 0, 2485, 3, "Diving"
                    },
                    {
                        new Guid("64c13f9a-5d7a-4800-a3a4-796538901269"),
                        "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 5, 8, 15, 18, 42, 199, DateTimeKind.Unspecified).AddTicks(4594),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Generic Rubber Salad", "One", "https://picsum.photos/640/480/?image=513", 555.09m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 8, 32, 3, "Diving"
                    },
                    {
                        new Guid("cb67959b-efad-45b6-8846-6b6f45313f22"),
                        "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 5, 11, 21, 17, 56, 547, DateTimeKind.Unspecified).AddTicks(4635),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Generic Wooden Pizza", "One", "https://picsum.photos/640/480/?image=1016", 586.56m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 5, 4286, 2, "Diving"
                    },
                    {
                        new Guid("c1131d81-8b3e-4a95-a27a-ebc285ef5442"),
                        "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 10, 22, 17, 17, 7, 678, DateTimeKind.Unspecified).AddTicks(4181),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Awesome Concrete Pants", "Two", "https://picsum.photos/640/480/?image=1018", 569.80m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 10, 1902, 2, "Racing"
                    },
                    {
                        new Guid("0fb8ec7e-7af1-4fe3-a2e2-000996ffd20f"),
                        "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 9, 22, 4, 10, 14, 325, DateTimeKind.Unspecified).AddTicks(1589),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Unbranded Granite Tuna", "Three", "https://picsum.photos/640/480/?image=392", 945.00m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 1, 4606, 2, "Diving"
                    },
                    {
                        new Guid("c6c95ab5-0bec-493a-a053-d0bf68ea7147"),
                        "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 4, 5, 5, 30, 37, 673, DateTimeKind.Unspecified).AddTicks(5784),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Unbranded Rubber Pants", "Two", "https://picsum.photos/640/480/?image=349", 554.46m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 9, 642, 1, "Family"
                    }
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "BootType", "Size"
                },
                new object[,]
                {
                    {
                        new Guid("2cb08fb9-e3c6-4b55-9434-42251d5b366e"),
                        "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 12, 23, 2, 6, 41, 900, DateTimeKind.Unspecified).AddTicks(2207),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Handcrafted Wooden Towels", "Two", "https://picsum.photos/640/480/?image=189", 708.89m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 9, 3820, "Drysuit", 30
                    },
                    {
                        new Guid("a34e5f34-f12c-4f68-a4f8-d62422b3f77e"),
                        "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 2, 8, 15, 53, 5, 893, DateTimeKind.Unspecified).AddTicks(2862),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Tasty Granite Shoes", "One", "https://picsum.photos/640/480/?image=123", 607.38m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 9, 365, "Harness", 28
                    },
                    {
                        new Guid("cae1842c-0a91-4d8f-8cf0-8dd9b93d84fc"),
                        "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 11, 27, 16, 42, 38, 646, DateTimeKind.Unspecified).AddTicks(8723),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Tasty Concrete Chicken", "Two", "https://picsum.photos/640/480/?image=998", 15.38m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 0, 1845, "Drysuit", 28
                    },
                    {
                        new Guid("5d1c12de-68d9-4a26-8169-208a58c0dfef"),
                        "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 10, 11, 11, 41, 53, 228, DateTimeKind.Unspecified).AddTicks(9158),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Sleek Frozen Chips", "Two", "https://picsum.photos/640/480/?image=346", 644.19m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 7, 3049, "Harness", 26
                    }
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("fed6325c-90b8-4f77-bdc5-f6f6feb0550d"),
                        "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 4, 11, 20, 9, 12, 65, DateTimeKind.Unspecified).AddTicks(7749),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Rustic Frozen Gloves", "Two", "https://picsum.photos/640/480/?image=385", 838.93m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 0, 351, 2, "Diving"
                    },
                    {
                        new Guid("8eeaf4b3-e743-40c5-95d8-54ac91421d85"),
                        "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 11, 10, 7, 55, 34, 168, DateTimeKind.Unspecified).AddTicks(7155),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Awesome Metal Mouse", "Two", "https://picsum.photos/640/480/?image=606", 511.30m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 7, 3938, 3, "Diving"
                    },
                    {
                        new Guid("25b9187b-0ea0-47fe-875c-e6def71f50bc"),
                        "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 9, 16, 22, 29, 17, 976, DateTimeKind.Unspecified).AddTicks(9489),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Handmade Plastic Bike", "One", "https://picsum.photos/640/480/?image=985", 432.98m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 4, 3824, 3, "Racing"
                    },
                    {
                        new Guid("81711422-062c-4283-89f9-2b2ba9522924"),
                        "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 3, 16, 3, 43, 40, 739, DateTimeKind.Unspecified).AddTicks(8679),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Gorgeous Fresh Table", "Two", "https://picsum.photos/640/480/?image=66", 839.97m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 0, 2662, 2, "Camping"
                    },
                    {
                        new Guid("8f4b1d30-c36c-49e6-8a91-562c6f7e9c4f"),
                        "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 27, 20, 52, 22, 622, DateTimeKind.Unspecified).AddTicks(8282),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Rustic Concrete Bike", "Three", "https://picsum.photos/640/480/?image=674", 56.47m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 2, 928, 3, "Fishing"
                    },
                    {
                        new Guid("240b0a6c-253c-4735-ba47-d17edb4bd96d"), "The Football Is Good For Training And Recreational Purposes",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 3, 20, 17, 47, 46, 276, DateTimeKind.Unspecified).AddTicks(8076),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Refined Granite Mouse", "Two", "https://picsum.photos/640/480/?image=180", 977.20m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 2, 3855, 3, "Diving"
                    },
                    {
                        new Guid("59ee7cec-f1d3-4479-bbdb-be439235826b"),
                        "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 6, 21, 19, 35, 5, 188, DateTimeKind.Unspecified).AddTicks(1387),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Refined Cotton Car", "Two", "https://picsum.photos/640/480/?image=2", 774.92m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 8, 1072, 1, "Fishing"
                    },
                    {
                        new Guid("942036e9-5fa6-481c-a64d-4ebc0138fb64"),
                        "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 9, 10, 0, 5, 2, 79, DateTimeKind.Unspecified).AddTicks(3814),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Handcrafted Cotton Chair", "One", "https://picsum.photos/640/480/?image=771", 494.11m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 9, 2319, 3, "Family"
                    },
                    {
                        new Guid("3083d42f-935e-46fd-93c5-be80a050498b"),
                        "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 9, 18, 9, 10, 8, 931, DateTimeKind.Unspecified).AddTicks(1288),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Practical Fresh Shoes", "Two", "https://picsum.photos/640/480/?image=97", 100.80m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 6, 3916, 3, "Family"
                    },
                    {
                        new Guid("a6f483dd-ddaa-4572-b5c0-451dd4b63b6f"),
                        "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 8, 24, 23, 24, 37, 253, DateTimeKind.Unspecified).AddTicks(9607),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Practical Cotton Hat", "Three", "https://picsum.photos/640/480/?image=1055", 69.70m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 2, 3765, 3, "Family"
                    },
                    {
                        new Guid("c8a3710c-1444-4971-8979-ca647df1572e"),
                        "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 17, 22, 31, 54, 572, DateTimeKind.Unspecified).AddTicks(1847),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Licensed Wooden Shirt", "One", "https://picsum.photos/640/480/?image=299", 572.37m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 10, 538, 1, "Fishing"
                    },
                    {
                        new Guid("77fcec69-45be-4d92-b4ed-a820ec7f0e49"),
                        "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 5, 3, 18, 58, 10, 194, DateTimeKind.Unspecified).AddTicks(4694),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Unbranded Steel Pants", "Three", "https://picsum.photos/640/480/?image=585", 449.78m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 0, 3956, 3, "Camping"
                    },
                    {
                        new Guid("267a92ee-96c5-4938-a5a4-7312db60a383"), "The Football Is Good For Training And Recreational Purposes",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 2, 18, 8, 36, 46, 564, DateTimeKind.Unspecified).AddTicks(3897),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Practical Plastic Chair", "One", "https://picsum.photos/640/480/?image=910", 337.67m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 1, 530, 2, "Camping"
                    },
                    {
                        new Guid("06d79d58-bb53-44f8-902d-358253220390"),
                        "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 10, 19, 17, 24, 24, 39, DateTimeKind.Unspecified).AddTicks(271),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Fantastic Fresh Soap", "One", "https://picsum.photos/640/480/?image=769", 669.77m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 5, 3878, 3, "Fishing"
                    },
                    {
                        new Guid("2f69534b-8313-4b75-89e2-ff14ccc33dab"), "The Football Is Good For Training And Recreational Purposes",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 7, 25, 15, 19, 29, 506, DateTimeKind.Unspecified).AddTicks(319),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Fantastic Plastic Shoes", "Three", "https://picsum.photos/640/480/?image=149", 868.93m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 0, 2649, 3, "Family"
                    },
                    {
                        new Guid("9cf241fc-464c-4a23-b685-737a815fd95e"),
                        "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 27, 1, 11, 7, 790, DateTimeKind.Unspecified).AddTicks(2877),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Practical Metal Sausages", "One", "https://picsum.photos/640/480/?image=349", 456.05m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 0, 3825, 1, "Fishing"
                    }
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "BootType", "Size"
                },
                new object[]
                {
                    new Guid("fcc09f26-b8cf-4946-a027-f702aeade1ac"), "The Football Is Good For Training And Recreational Purposes", "Boot",
                    new DateTimeOffset(new DateTime(2021, 5, 29, 11, 28, 11, 327, DateTimeKind.Unspecified).AddTicks(467),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "Tasty Wooden Towels", "One", "https://picsum.photos/640/480/?image=997", 705.77m,
                    new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 6, 3913, "Chelsea", 26
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[]
                {
                    new Guid("0b223681-9237-4a12-aa05-921b8c9eab43"),
                    "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                    "Kayak",
                    new DateTimeOffset(new DateTime(2021, 1, 31, 8, 41, 43, 645, DateTimeKind.Unspecified).AddTicks(7025),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "Tasty Granite Fish", "One", "https://picsum.photos/640/480/?image=489", 800.21m,
                    new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 4, 2257, 2, "Racing"
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "BootType", "Size"
                },
                new object[,]
                {
                    {
                        new Guid("9844deb8-7232-4cb3-8c99-111fb988f695"),
                        "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 12, 5, 8, 16, 9, 8, DateTimeKind.Unspecified).AddTicks(3786),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Incredible Plastic Shoes", "One", "https://picsum.photos/640/480/?image=616", 917.50m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 4, 4823, "Chelsea", 26
                    },
                    {
                        new Guid("9045fe40-5994-4aca-b532-a113e9250d49"), "The Football Is Good For Training And Recreational Purposes",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 7, 28, 15, 33, 48, 854, DateTimeKind.Unspecified).AddTicks(9280),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Intelligent Steel Gloves", "Three", "https://picsum.photos/640/480/?image=727", 423.35m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 3, 2915, "Chelsea", 25
                    },
                    {
                        new Guid("59546852-e6b0-4c14-b1d1-bb3a50017614"),
                        "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 6, 16, 16, 56, 9, 410, DateTimeKind.Unspecified).AddTicks(727),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Practical Granite Chips", "Three", "https://picsum.photos/640/480/?image=1070", 875.64m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 6, 3992, "Engineer", 20
                    },
                    {
                        new Guid("d446e908-2821-448a-88b0-32a43945061f"),
                        "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 5, 14, 0, 36, 13, 108, DateTimeKind.Unspecified).AddTicks(2084),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Generic Granite Table", "Two", "https://picsum.photos/640/480/?image=540", 908.73m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 0, 2946, "Drysuit", 24
                    },
                    {
                        new Guid("8b12d7c6-785a-405f-bd54-b9f038662d4a"),
                        "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 6, 21, 7, 29, 3, 470, DateTimeKind.Unspecified).AddTicks(7130),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Small Plastic Sausages", "Two", "https://picsum.photos/640/480/?image=895", 98.83m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 4, 1841, "Chelsea", 30
                    },
                    {
                        new Guid("bd3cd86d-8e6d-4921-bf26-2a9dfe86bcff"),
                        "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 7, 14, 12, 20, 35, 777, DateTimeKind.Unspecified).AddTicks(3397),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Incredible Rubber Bike", "Two", "https://picsum.photos/640/480/?image=874", 192.06m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 7, 939, "Cowboy", 20
                    },
                    {
                        new Guid("f558dfef-be54-440e-a28e-947f509cde1d"), "The Football Is Good For Training And Recreational Purposes",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 6, 28, 4, 30, 23, 573, DateTimeKind.Unspecified).AddTicks(7993),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Sleek Cotton Sausages", "Two", "https://picsum.photos/640/480/?image=859", 820.61m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 4, 4791, "Drysuit", 27
                    },
                    {
                        new Guid("3f39c779-5c16-49da-ba1a-f931f5dd467a"),
                        "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 11, 7, 8, 52, 22, 263, DateTimeKind.Unspecified).AddTicks(4873),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Sleek Plastic Pants", "Two", "https://picsum.photos/640/480/?image=112", 354.26m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 3, 4139, "Harness", 22
                    },
                    {
                        new Guid("057bc6a0-c7b5-4d09-a255-24157ccbcd08"),
                        "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 9, 16, 15, 59, 1, 962, DateTimeKind.Unspecified).AddTicks(2727),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Tasty Granite Table", "Two", "https://picsum.photos/640/480/?image=402", 44.41m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 5, 264, "Harness", 21
                    },
                    {
                        new Guid("ae9e418e-4033-4268-95ed-b51108b7bf6c"),
                        "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 4, 21, 8, 32, 37, 223, DateTimeKind.Unspecified).AddTicks(6622),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Unbranded Steel Soap", "Three", "https://picsum.photos/640/480/?image=672", 955.38m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 6, 3305, "Cowboy", 24
                    },
                    {
                        new Guid("41bce70c-bda7-452a-95a5-7a47585c4043"), "The Football Is Good For Training And Recreational Purposes",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 3, 24, 6, 46, 4, 751, DateTimeKind.Unspecified).AddTicks(4424),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Incredible Metal Gloves", "Three", "https://picsum.photos/640/480/?image=719", 526.28m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 1, 3204, "Football", 30
                    },
                    {
                        new Guid("8c7d6f41-5fdf-4820-91e5-b0c45f8554b8"),
                        "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 9, 5, 17, 18, 49, 306, DateTimeKind.Unspecified).AddTicks(7580),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Tasty Cotton Sausages", "One", "https://picsum.photos/640/480/?image=674", 62.68m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 1, 95, "Cowboy", 24
                    },
                    {
                        new Guid("575e11f4-606f-4443-88dd-5e6bd070f77a"),
                        "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 5, 10, 8, 40, 30, 935, DateTimeKind.Unspecified).AddTicks(7392),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Fantastic Wooden Tuna", "Two", "https://picsum.photos/640/480/?image=434", 774.56m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 6, 4502, "Harness", 22
                    },
                    {
                        new Guid("32387293-f009-46d6-966b-eda712fa4a47"),
                        "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 7, 14, 19, 3, 17, 119, DateTimeKind.Unspecified).AddTicks(1290),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Practical Concrete Bacon", "Two", "https://picsum.photos/640/480/?image=616", 848.03m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 3, 2344, "Cowboy", 28
                    },
                    {
                        new Guid("81c7ad72-f067-44fd-ab95-bcd26edc3379"),
                        "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 8, 15, 9, 45, 26, 442, DateTimeKind.Unspecified).AddTicks(1252),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Unbranded Granite Chair", "Three", "https://picsum.photos/640/480/?image=13", 472.97m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 0, 2323, "Chelsea", 26
                    },
                    {
                        new Guid("629b997b-340a-496f-baf2-485230cc8b64"),
                        "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 11, 10, 19, 58, 24, 450, DateTimeKind.Unspecified).AddTicks(7199),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Rustic Concrete Bike", "Three", "https://picsum.photos/640/480/?image=718", 148.89m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 4, 27, "Football", 22
                    },
                    {
                        new Guid("40c09cce-15af-4979-b18f-dc2a3c5484c2"),
                        "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 8, 14, 11, 44, 18, 916, DateTimeKind.Unspecified).AddTicks(7685),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Handcrafted Rubber Salad", "Three", "https://picsum.photos/640/480/?image=16", 220.79m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 5, 3522, "Engineer", 28
                    },
                    {
                        new Guid("8eb3617f-14ec-4b65-8e26-4c66f9433889"),
                        "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 9, 28, 14, 59, 51, 898, DateTimeKind.Unspecified).AddTicks(949),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Fantastic Plastic Chicken", "One", "https://picsum.photos/640/480/?image=461", 579.58m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 6, 1022, "Chelsea", 23
                    },
                    {
                        new Guid("35bcab45-853e-426a-ba0e-3c192e084704"),
                        "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 3, 27, 18, 18, 13, 74, DateTimeKind.Unspecified).AddTicks(5289),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Handcrafted Fresh Chair", "Two", "https://picsum.photos/640/480/?image=384", 664.30m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 10, 2470, "Engineer", 23
                    },
                    {
                        new Guid("b8c78bac-1402-4b09-9f14-3be016fcf4fd"),
                        "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 3, 27, 15, 13, 21, 319, DateTimeKind.Unspecified).AddTicks(9364),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Rustic Metal Car", "Three", "https://picsum.photos/640/480/?image=575", 359.21m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 10, 4850, "Football", 20
                    },
                    {
                        new Guid("d8c7c3b2-01b1-4ff4-94f3-9db44e9aa8d6"),
                        "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 9, 27, 14, 29, 49, 476, DateTimeKind.Unspecified).AddTicks(5140),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Fantastic Steel Towels", "Two", "https://picsum.photos/640/480/?image=782", 720.93m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 7, 611, "Drysuit", 24
                    },
                    {
                        new Guid("d88bd910-2df6-4117-9380-5fbbfeeac333"),
                        "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 11, 14, 8, 7, 37, 756, DateTimeKind.Unspecified).AddTicks(3527),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Intelligent Frozen Car", "Two", "https://picsum.photos/640/480/?image=675", 249.60m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 2, 2659, "Football", 27
                    },
                    {
                        new Guid("bec2206f-4749-4f99-bb3a-f83a67996d2a"),
                        "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 7, 28, 21, 59, 43, 63, DateTimeKind.Unspecified).AddTicks(4820),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Intelligent Fresh Sausages", "One", "https://picsum.photos/640/480/?image=963", 789.49m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 7, 2112, "Cowboy", 25
                    },
                    {
                        new Guid("69756e5f-07e7-4fb1-9c99-7563db85ac4c"),
                        "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 3, 5, 11, 52, 35, 731, DateTimeKind.Unspecified).AddTicks(7939),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Awesome Cotton Chicken", "Two", "https://picsum.photos/640/480/?image=98", 455.90m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 5, 4171, "Cowboy", 25
                    },
                    {
                        new Guid("ca385169-ba52-47d0-91d0-e90cab38b6ab"),
                        "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 5, 16, 13, 17, 41, 995, DateTimeKind.Unspecified).AddTicks(2663),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Handcrafted Metal Computer", "One", "https://picsum.photos/640/480/?image=721", 478.64m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 5, 2478, "Harness", 29
                    },
                    {
                        new Guid("4d1b50b6-36c3-4910-849c-73b5f2236afc"),
                        "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Boot",
                        new DateTimeOffset(new DateTime(2021, 5, 26, 5, 45, 49, 31, DateTimeKind.Unspecified).AddTicks(6834),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Unbranded Soft Gloves", "Three", "https://picsum.photos/640/480/?image=62", 339.92m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 4, 2800, "Football", 20
                    },
                    {
                        new Guid("5f6f7325-f995-4ff9-8e41-c09909069c74"),
                        "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 8, 31, 17, 13, 44, 138, DateTimeKind.Unspecified).AddTicks(8969),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Intelligent Rubber Gloves", "Two", "https://picsum.photos/640/480/?image=29", 248.71m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 10, 294, "Harness", 20
                    },
                    {
                        new Guid("af55eede-0538-4551-ad85-6f5c214d1577"),
                        "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Boot",
                        new DateTimeOffset(new DateTime(2020, 8, 22, 10, 34, 54, 639, DateTimeKind.Unspecified).AddTicks(1545),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Unbranded Soft Pants", "One", "https://picsum.photos/640/480/?image=150", 41.82m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 3, 3404, "Chelsea", 29
                    },
                    {
                        new Guid("4d19c782-9103-4c60-a56e-fb79f6e076f7"),
                        "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 6, 10, 21, 30, 49, 420, DateTimeKind.Unspecified).AddTicks(3270),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Fantastic Frozen Cheese", "Two", "https://picsum.photos/640/480/?image=149", 486.99m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 0, 1258, "Cowboy", 24
                    },
                    {
                        new Guid("ff6b0a66-157c-4215-868a-26d6466ef9a0"),
                        "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Boot",
                        new DateTimeOffset(new DateTime(2021, 4, 11, 13, 2, 27, 487, DateTimeKind.Unspecified).AddTicks(6030),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Gorgeous Granite Towels", "Three", "https://picsum.photos/640/480/?image=179", 594.53m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 8, 2650, "Harness", 30
                    }
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("ff27a18c-4098-4451-8110-a6e936e646a4"),
                        "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 9, 3, 0, 27, 51, 212, DateTimeKind.Unspecified).AddTicks(9638),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Handcrafted Granite Pizza", "Three", "https://picsum.photos/640/480/?image=448", 271.26m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 3, 2198, 3, "Diving"
                    },
                    {
                        new Guid("cd33bc3e-a8f7-4ee2-8ff4-56f89848bc10"),
                        "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 4, 6, 15, 23, 38, 704, DateTimeKind.Unspecified).AddTicks(8200),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Licensed Metal Sausages", "Two", "https://picsum.photos/640/480/?image=165", 925.99m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 4, 1227, 1, "Family"
                    },
                    {
                        new Guid("88d565ec-2de0-432e-a820-0652cb53ae22"),
                        "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 7, 6, 13, 2, 17, 849, DateTimeKind.Unspecified).AddTicks(3332),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Small Wooden Computer", "One", "https://picsum.photos/640/480/?image=540", 464.29m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 6, 3780, 2, "Diving"
                    },
                    {
                        new Guid("15202255-1451-42a6-b6e3-59da42272e55"),
                        "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 7, 4, 17, 47, 30, 429, DateTimeKind.Unspecified).AddTicks(1882),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Tasty Rubber Pants", "One", "https://picsum.photos/640/480/?image=270", 848.57m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 3, 4910, 3, "Diving"
                    },
                    {
                        new Guid("cc545bec-26e3-4bb9-a117-9bdf37f3b5d7"),
                        "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 5, 23, 11, 22, 31, 397, DateTimeKind.Unspecified).AddTicks(3380),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Licensed Rubber Car", "Two", "https://picsum.photos/640/480/?image=988", 527.88m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 9, 4005, 3, "Diving"
                    }
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "BootType", "Size"
                },
                new object[]
                {
                    new Guid("4e8587b2-2ee1-47f3-887f-b699f2283e02"), "The Football Is Good For Training And Recreational Purposes", "Boot",
                    new DateTimeOffset(new DateTime(2021, 7, 14, 19, 22, 15, 375, DateTimeKind.Unspecified).AddTicks(3124),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "Generic Fresh Ball", "Three", "https://picsum.photos/640/480/?image=437", 108.39m,
                    new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 4, 1181, "Cowboy", 27
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[]
                {
                    new Guid("bbb4e3a1-d3d2-4238-854f-fac812ab21f6"),
                    "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                    "Kayak",
                    new DateTimeOffset(new DateTime(2020, 12, 21, 20, 16, 55, 33, DateTimeKind.Unspecified).AddTicks(3851),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "Handcrafted Plastic Pizza", "Three", "https://picsum.photos/640/480/?image=643", 962.57m,
                    new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 1, 643, 2, "Camping"
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "BootType", "Size"
                },
                new object[]
                {
                    new Guid("ac8d842f-3363-49c4-81f0-0de180f583b8"),
                    "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                    "Boot",
                    new DateTimeOffset(new DateTime(2021, 1, 13, 15, 42, 12, 448, DateTimeKind.Unspecified).AddTicks(6774),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "Handcrafted Concrete Table", "Three", "https://picsum.photos/640/480/?image=473", 196.27m,
                    new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 9, 651, "Engineer", 20
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("61d59e69-1179-4f51-8b1e-befd5239e17b"),
                        "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 1, 23, 6, 16, 12, 882, DateTimeKind.Unspecified).AddTicks(8346),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Ergonomic Cotton Ball", "Three", "https://picsum.photos/640/480/?image=753", 930.00m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 8, 2908, "DayPack"
                    },
                    {
                        new Guid("c76d26b6-af93-4bf0-95ac-d99f64fbe450"),
                        "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 7, 14, 15, 36, 47, 451, DateTimeKind.Unspecified).AddTicks(3012),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Fantastic Plastic Computer", "One", "https://picsum.photos/640/480/?image=705", 752.24m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 5, 3006, "Cycling"
                    },
                    {
                        new Guid("3846483b-cd9c-47f0-a2eb-ae7f103fa905"),
                        "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 7, 21, 13, 5, 40, 200, DateTimeKind.Unspecified).AddTicks(2311),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Practical Plastic Chair", "Three", "https://picsum.photos/640/480/?image=38", 330.26m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 10, 313, "DayPack"
                    },
                    {
                        new Guid("3696b5a3-8270-442d-bebe-3726ea0234a8"),
                        "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 2, 23, 17, 24, 9, 355, DateTimeKind.Unspecified).AddTicks(7553),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Practical Steel Chips", "Three", "https://picsum.photos/640/480/?image=82", 472.54m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 10, 2377, "Cycling"
                    },
                    {
                        new Guid("f3c562c7-ea04-4ac8-979c-b4c6b501ff44"),
                        "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 2, 5, 22, 46, 12, 974, DateTimeKind.Unspecified).AddTicks(2148),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Small Granite Pants", "Two", "https://picsum.photos/640/480/?image=906", 218.34m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 5, 790, "Climbing"
                    },
                    {
                        new Guid("9fced0c7-8cb4-44cd-8e42-e8d2da434616"),
                        "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 11, 9, 12, 33, 37, 872, DateTimeKind.Unspecified).AddTicks(716),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Handmade Fresh Bacon", "One", "https://picsum.photos/640/480/?image=712", 298.45m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 1, 1098, "Hiking"
                    },
                    {
                        new Guid("93dbf2ea-dff0-453f-9a25-614d2793c878"),
                        "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 12, 29, 15, 0, 56, 447, DateTimeKind.Unspecified).AddTicks(7570),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Unbranded Rubber Table", "Three", "https://picsum.photos/640/480/?image=519", 518.56m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 5, 1179, "Cycling"
                    },
                    {
                        new Guid("f3cec9bc-ce15-4d6e-8902-a3cf32e4c02c"),
                        "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 1, 1, 9, 26, 50, 963, DateTimeKind.Unspecified).AddTicks(2319),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Unbranded Frozen Gloves", "Three", "https://picsum.photos/640/480/?image=716", 994.99m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 1, 1262, "Climbing"
                    },
                    {
                        new Guid("64ca72c9-67b2-4feb-a079-4ad1f570f4a8"),
                        "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 6, 4, 17, 22, 52, 10, DateTimeKind.Unspecified).AddTicks(1892),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Sleek Frozen Car", "One", "https://picsum.photos/640/480/?image=121", 633.31m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 4, 2729, "Hiking"
                    },
                    {
                        new Guid("36307fbd-3c7f-498a-9e17-46f195467330"),
                        "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 4, 1, 2, 46, 3, 861, DateTimeKind.Unspecified).AddTicks(3368),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Refined Wooden Bacon", "One", "https://picsum.photos/640/480/?image=119", 934.18m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 9, 813, "Snowsports"
                    },
                    {
                        new Guid("5d30bb95-a9c4-4c92-872a-6e1692cb918e"),
                        "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 2, 23, 18, 17, 49, 239, DateTimeKind.Unspecified).AddTicks(965),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Intelligent Plastic Pizza", "One", "https://picsum.photos/640/480/?image=171", 857.72m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 8, 4296, "Snowsports"
                    },
                    {
                        new Guid("917ef761-36c5-491d-93f1-91f2604ed0d2"),
                        "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 10, 30, 14, 47, 57, 190, DateTimeKind.Unspecified).AddTicks(1957),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Ergonomic Rubber Shoes", "Three", "https://picsum.photos/640/480/?image=637", 529.46m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 6, 4643, "Snowsports"
                    },
                    {
                        new Guid("2f9a86c1-4d64-4fe2-a7a7-8b5b2e2feaa4"), "The Football Is Good For Training And Recreational Purposes",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 3, 4, 8, 24, 46, 189, DateTimeKind.Unspecified).AddTicks(7682),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Licensed Wooden Bacon", "Two", "https://picsum.photos/640/480/?image=602", 567.81m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 4, 1220, "Hiking"
                    },
                    {
                        new Guid("d5c89d53-ba33-45c0-b4eb-91764c56810e"),
                        "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 7, 1, 15, 3, 35, 579, DateTimeKind.Unspecified).AddTicks(803),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Awesome Fresh Towels", "Three", "https://picsum.photos/640/480/?image=58", 863.08m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 0, 793, "Overnight"
                    },
                    {
                        new Guid("18b89c40-be9d-44e9-ae5d-e2b95bc7d271"),
                        "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 1, 20, 17, 7, 8, 662, DateTimeKind.Unspecified).AddTicks(5588),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Small Cotton Car", "Three", "https://picsum.photos/640/480/?image=878", 32.79m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 7, 4456, "DayPack"
                    },
                    {
                        new Guid("e17912ef-bcc9-4f2a-86e5-8f682f40ab39"),
                        "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 9, 17, 13, 23, 18, 455, DateTimeKind.Unspecified).AddTicks(6064),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Intelligent Cotton Mouse", "One", "https://picsum.photos/640/480/?image=868", 104.59m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 5, 4753, "Overnight"
                    }
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "BootType", "Size"
                },
                new object[]
                {
                    new Guid("c971cb9a-9615-4f03-9271-0541793e9812"),
                    "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                    "Boot",
                    new DateTimeOffset(new DateTime(2021, 4, 19, 19, 41, 5, 177, DateTimeKind.Unspecified).AddTicks(9151),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "Unbranded Plastic Gloves", "One", "https://picsum.photos/640/480/?image=375", 889.33m,
                    new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 8, 1810, "Harness", 29
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("e3980585-6d89-4ca8-843f-7a35a504629d"),
                        "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 1, 15, 17, 56, 37, 228, DateTimeKind.Unspecified).AddTicks(7076),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Intelligent Wooden Computer", "Two", "https://picsum.photos/640/480/?image=432", 509.42m,
                        new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 5, 803, 2, "Camping"
                    },
                    {
                        new Guid("2d794ba4-ad87-4205-974e-8d11826a09ea"),
                        "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Kayak",
                        new DateTimeOffset(new DateTime(2020, 12, 3, 16, 5, 27, 70, DateTimeKind.Unspecified).AddTicks(2091),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Intelligent Concrete Chair", "Two", "https://picsum.photos/640/480/?image=469", 584.38m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 9, 3729, 2, "Racing"
                    },
                    {
                        new Guid("203caae9-8bf3-436b-a76a-34518f048919"),
                        "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 11, 27, 20, 15, 41, 184, DateTimeKind.Unspecified).AddTicks(8430),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Practical Concrete Ball", "One", "https://picsum.photos/640/480/?image=841", 657.32m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 7, 1694, 1, "Racing"
                    }
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("d3b75333-7c71-4f7f-9072-fbf0700b3a42"),
                        "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 6, 4, 1, 48, 26, 596, DateTimeKind.Unspecified).AddTicks(1368),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Tasty Fresh Cheese", "One", "https://picsum.photos/640/480/?image=1052", 997.98m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 3, 2422, "Climbing"
                    },
                    {
                        new Guid("bd081703-2935-40d2-a3e5-c6022f2c469c"),
                        "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Backpack",
                        new DateTimeOffset(new DateTime(2021, 3, 30, 5, 39, 39, 465, DateTimeKind.Unspecified).AddTicks(4640),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Sleek Plastic Sausages", "One", "https://picsum.photos/640/480/?image=356", 927.03m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 9, 4140, "Hiking"
                    },
                    {
                        new Guid("9edb16e3-fa6b-4f52-94b4-3bd759585218"),
                        "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 10, 14, 11, 7, 47, 587, DateTimeKind.Unspecified).AddTicks(3746),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Licensed Wooden Chicken", "Two", "https://picsum.photos/640/480/?image=90", 702.78m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 7, 2587, "Snowsports"
                    },
                    {
                        new Guid("b4fe2d01-ef6d-4cd2-ab72-a62afdfb3ced"),
                        "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 3, 2, 16, 39, 9, 458, DateTimeKind.Unspecified).AddTicks(9203),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Practical Steel Ball", "Two", "https://picsum.photos/640/480/?image=478", 275.84m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 1, 1000, "DayPack"
                    },
                    {
                        new Guid("513c52fc-48f2-436f-a31b-7a87974d1796"),
                        "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 8, 6, 8, 6, 3, 450, DateTimeKind.Unspecified).AddTicks(1531),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Incredible Frozen Gloves", "Three", "https://picsum.photos/640/480/?image=77", 837.00m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 9, 1627, "Climbing"
                    },
                    {
                        new Guid("bf26f744-2520-4cf9-b500-a243be8b3d5f"),
                        "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 4, 11, 20, 21, 32, 208, DateTimeKind.Unspecified).AddTicks(7956),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Generic Rubber Keyboard", "Two", "https://picsum.photos/640/480/?image=23", 819.93m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 9, 1952, "Overnight"
                    }
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "BootType", "Size"
                },
                new object[,]
                {
                    {
                        new Guid("2b3e6af5-0539-433a-a17b-0bb6c0a2c5f6"),
                        "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 11, 29, 23, 16, 16, 27, DateTimeKind.Unspecified).AddTicks(8998),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Handmade Metal Chicken", "Two", "https://picsum.photos/640/480/?image=563", 365.95m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 4, 1383, "Chelsea", 20
                    },
                    {
                        new Guid("afb8f5fb-cd1d-40dc-abec-b10e0ed74bea"),
                        "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 3, 14, 3, 31, 40, 577, DateTimeKind.Unspecified).AddTicks(7559),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Unbranded Wooden Mouse", "Three", "https://picsum.photos/640/480/?image=83", 794.30m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 4, 2024, "Football", 30
                    },
                    {
                        new Guid("e2469fbd-5e42-48c3-89d7-0e7f3174ec8e"),
                        "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 12, 19, 8, 16, 42, 82, DateTimeKind.Unspecified).AddTicks(2763),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Handmade Plastic Chair", "One", "https://picsum.photos/640/480/?image=273", 742.04m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 0, 2008, "Football", 22
                    },
                    {
                        new Guid("ebf485be-98d3-49fc-8a13-d3d53b808e44"),
                        "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Boot",
                        new DateTimeOffset(new DateTime(2021, 3, 17, 6, 34, 3, 667, DateTimeKind.Unspecified).AddTicks(4422),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Gorgeous Rubber Salad", "Two", "https://picsum.photos/640/480/?image=865", 511.56m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 4, 3477, "Football", 26
                    },
                    {
                        new Guid("a036952a-6b68-4a74-af0f-4a2528250e2e"),
                        "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 11, 21, 15, 1, 35, 289, DateTimeKind.Unspecified).AddTicks(5628),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Rustic Granite Bike", "Three", "https://picsum.photos/640/480/?image=309", 220.13m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 2, 1737, "Football", 22
                    },
                    {
                        new Guid("968be106-bbad-4bfc-9c61-f86fffa6ca89"), "The Football Is Good For Training And Recreational Purposes",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 1, 11, 9, 29, 12, 624, DateTimeKind.Unspecified).AddTicks(5798),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Licensed Metal Table", "Two", "https://picsum.photos/640/480/?image=517", 833.38m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 5, 2373, "Cowboy", 24
                    },
                    {
                        new Guid("c8c3d15f-e28c-4030-8609-7ee039cd4698"),
                        "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 7, 5, 21, 51, 10, 118, DateTimeKind.Unspecified).AddTicks(2364),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Licensed Concrete Keyboard", "Three", "https://picsum.photos/640/480/?image=144", 161.40m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 7, 210, "Drysuit", 23
                    },
                    {
                        new Guid("1b29941d-959d-400d-b6f6-789185e5dadd"),
                        "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                        "Boot",
                        new DateTimeOffset(new DateTime(2020, 8, 29, 15, 53, 11, 842, DateTimeKind.Unspecified).AddTicks(2583),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Refined Soft Tuna", "Two", "https://picsum.photos/640/480/?image=262", 451.77m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 7, 427, "Football", 27
                    },
                    {
                        new Guid("cabf6c1a-9794-4fdd-a04c-799a33015f9f"),
                        "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                        "Boot",
                        new DateTimeOffset(new DateTime(2021, 6, 24, 11, 30, 9, 191, DateTimeKind.Unspecified).AddTicks(4736),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Handmade Rubber Mouse", "One", "https://picsum.photos/640/480/?image=695", 100.06m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 7, 2086, "Drysuit", 25
                    }
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[]
                {
                    new Guid("6ed539d4-5a74-4e0a-a2ac-aaeeac374ff5"),
                    "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Backpack",
                    new DateTimeOffset(new DateTime(2021, 7, 6, 14, 5, 38, 130, DateTimeKind.Unspecified).AddTicks(9489),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "Generic Frozen Car", "One", "https://picsum.photos/640/480/?image=436", 949.05m,
                    new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 6, 4487, "Overnight"
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[]
                {
                    new Guid("7488a038-8b45-4254-8657-8392cc75ddcb"),
                    "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                    "Kayak",
                    new DateTimeOffset(new DateTime(2020, 11, 3, 2, 44, 29, 617, DateTimeKind.Unspecified).AddTicks(7309),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "Sleek Steel Car", "Two", "https://picsum.photos/640/480/?image=570", 731.55m,
                    new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 8, 4153, 1, "Fishing"
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("86d40d1a-6b49-434f-a145-abca7ec768b4"), "The Football Is Good For Training And Recreational Purposes",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 5, 31, 6, 24, 20, 80, DateTimeKind.Unspecified).AddTicks(3744),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Unbranded Granite Hat", "Three", "https://picsum.photos/640/480/?image=554", 652.30m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 7, 4943, "Snowsports"
                    },
                    {
                        new Guid("2f731a78-1a72-4f83-bb9f-9ce39d05a859"),
                        "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 1, 7, 6, 19, 16, 820, DateTimeKind.Unspecified).AddTicks(1995),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Licensed Steel Fish", "Three", "https://picsum.photos/640/480/?image=702", 192.79m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 6, 4493, "Hiking"
                    }
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[,]
                {
                    {
                        new Guid("bd78af8b-341a-450b-946b-3240484d8199"),
                        "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 4, 17, 1, 25, 22, 488, DateTimeKind.Unspecified).AddTicks(346),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Incredible Concrete Pants", "One", "https://picsum.photos/640/480/?image=713", 267.52m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 8, 978, 1, "Fishing"
                    },
                    {
                        new Guid("a24dc940-bbd2-4faa-97e2-d1e96ab49131"),
                        "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 7, 15, 12, 49, 6, 505, DateTimeKind.Unspecified).AddTicks(4678),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Fantastic Granite Sausages", "Three", "https://picsum.photos/640/480/?image=444", 139.40m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 6, 3085, 1, "Fishing"
                    },
                    {
                        new Guid("b6cb1aa9-e851-4af3-9e58-7f5c0867aea5"),
                        "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 8, 4, 2, 9, 21, 228, DateTimeKind.Unspecified).AddTicks(583),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Handmade Granite Hat", "Two", "https://picsum.photos/640/480/?image=806", 547.42m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 3, 96, 1, "Fishing"
                    },
                    {
                        new Guid("4d6a9336-df9e-41b0-a2d8-06c4f0ee4591"),
                        "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 3, 31, 6, 17, 29, 681, DateTimeKind.Unspecified).AddTicks(2912),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Small Plastic Gloves", "Three", "https://picsum.photos/640/480/?image=174", 620.55m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 3, 4396, 1, "Family"
                    },
                    {
                        new Guid("bc6ee119-4403-4b3c-9983-1d9ec23e6268"),
                        "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2020, 9, 2, 5, 1, 3, 990, DateTimeKind.Unspecified).AddTicks(8313),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Practical Granite Shoes", "One", "https://picsum.photos/640/480/?image=436", 377.99m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 1, 1214, 1, "Racing"
                    },
                    {
                        new Guid("0f64ff7a-de03-4b1c-b37c-7f7c9554a0e8"),
                        "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                        "Kayak",
                        new DateTimeOffset(new DateTime(2021, 6, 6, 16, 45, 50, 278, DateTimeKind.Unspecified).AddTicks(3305),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Intelligent Frozen Towels", "Two", "https://picsum.photos/640/480/?image=684", 279.00m,
                        new Guid("9a3a7f80-3838-4d05-8c58-f5e97e65c122"), 6, 3398, 1, "Family"
                    }
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "BackpackType"
                },
                new object[,]
                {
                    {
                        new Guid("aa6a18e4-aa44-42c2-897f-06865a4a6b45"),
                        "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 7, 30, 16, 35, 16, 66, DateTimeKind.Unspecified).AddTicks(1144),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Practical Granite Towels", "Two", "https://picsum.photos/640/480/?image=495", 931.73m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 8, 51, "Climbing"
                    },
                    {
                        new Guid("8dafb046-60df-48ca-bfc5-69db91b77aa9"),
                        "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 7, 10, 7, 24, 37, 685, DateTimeKind.Unspecified).AddTicks(746),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Awesome Concrete Bike", "Two", "https://picsum.photos/640/480/?image=1023", 348.13m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 7, 1009, "Hiking"
                    },
                    {
                        new Guid("5c9ba41a-20db-4bbe-b2f8-56502f6d763b"),
                        "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 3, 19, 14, 42, 23, 871, DateTimeKind.Unspecified).AddTicks(3695),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Ergonomic Frozen Computer", "Two", "https://picsum.photos/640/480/?image=79", 354.02m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 5, 814, "Overnight"
                    },
                    {
                        new Guid("dc6c6e75-3910-4d53-808a-10730fd08536"),
                        "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 8, 13, 23, 24, 44, 114, DateTimeKind.Unspecified).AddTicks(8358),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Ergonomic Steel Shoes", "Two", "https://picsum.photos/640/480/?image=975", 134.57m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 2, 3653, "Snowsports"
                    },
                    {
                        new Guid("428c4b8d-b75a-4859-b7b9-af4429122d0b"),
                        "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 5, 15, 12, 9, 29, 183, DateTimeKind.Unspecified).AddTicks(3122),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Tasty Rubber Computer", "One", "https://picsum.photos/640/480/?image=508", 388.95m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 1, 3523, "DayPack"
                    },
                    {
                        new Guid("11ab7803-35ff-408b-a885-0c5116cfc7ea"),
                        "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 9, 3, 6, 34, 35, 210, DateTimeKind.Unspecified).AddTicks(9465),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Ergonomic Frozen Chips", "Three", "https://picsum.photos/640/480/?image=368", 237.68m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 7, 735, "Hiking"
                    },
                    {
                        new Guid("3a32c61a-af7c-4c26-9a56-a069af5559b5"),
                        "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 2, 18, 23, 58, 48, 735, DateTimeKind.Unspecified).AddTicks(7356),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Handcrafted Frozen Pants", "One", "https://picsum.photos/640/480/?image=504", 561.06m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 8, 4616, "Climbing"
                    },
                    {
                        new Guid("76652a41-c159-4590-8ad0-98b0a844cc5e"),
                        "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 10, 19, 11, 42, 32, 897, DateTimeKind.Unspecified).AddTicks(376),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Handmade Granite Towels", "Three", "https://picsum.photos/640/480/?image=197", 527.29m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 8, 3511, "Hiking"
                    },
                    {
                        new Guid("b5494f6d-b3c3-4576-a440-5b6f3538b69b"),
                        "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2021, 4, 16, 10, 40, 14, 34, DateTimeKind.Unspecified).AddTicks(4874),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Generic Metal Computer", "One", "https://picsum.photos/640/480/?image=479", 78.93m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 10, 4788, "Snowsports"
                    },
                    {
                        new Guid("b8f25061-d6fa-441c-b846-5b8a8b7ad3bd"),
                        "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                        "Backpack",
                        new DateTimeOffset(new DateTime(2020, 11, 9, 7, 3, 15, 197, DateTimeKind.Unspecified).AddTicks(4930),
                            new TimeSpan(0, -3, 0, 0, 0)),
                        "Unbranded Soft Mouse", "Three", "https://picsum.photos/640/480/?image=103", 689.59m,
                        new Guid("7d5ef912-5bb9-4681-a85a-49da666cfaa0"), 4, 3060, "Cycling"
                    }
                });

            migrationBuilder.InsertData(
                "Products",
                new[]
                {
                    "Id", "Description", "Discriminator", "IntroduceAt", "Name", "Option", "PhotoUrl", "Price", "ProductTypeId", "Rating",
                    "Stock", "AmountOfPerson", "KayakType"
                },
                new object[]
                {
                    new Guid("bde96628-6ad5-4247-9d08-0233021db601"), "The Football Is Good For Training And Recreational Purposes",
                    "Kayak",
                    new DateTimeOffset(new DateTime(2021, 1, 4, 6, 43, 21, 548, DateTimeKind.Unspecified).AddTicks(2644),
                        new TimeSpan(0, -3, 0, 0, 0)),
                    "Generic Wooden Gloves", "Two", "https://picsum.photos/640/480/?image=520", 3.65m,
                    new Guid("51274108-5d2a-4b3c-aa6c-f69919c9235d"), 8, 521, 3, "Camping"
                });

            migrationBuilder.InsertData(
                "Reviews",
                new[] {"Id", "Comment", "ProductId", "Title"},
                new object[,]
                {
                    {
                        new Guid("f8890cea-adfb-4494-9d34-90cf27b56604"),
                        "Nihil porro voluptates et expedita laborum enim nihil voluptatum quam. Voluptates distinctio nesciunt officiis nam similique sit enim. Harum voluptatem molestiae est aliquid perferendis dolores quisquam. Tempora id facere rerum est maiores sunt nemo nihil quod.\n\nDeserunt consequatur qui asperiores accusamus dignissimos maxime repudiandae at. Et voluptatibus minus ut neque quis ullam sint. Sed officia quod dolore nobis officiis delectus aut. Repellendus ex eos odio. Officiis eaque aliquam nulla et. Similique placeat aut aut iste quos.\n\nLaboriosam dolorem et consequatur. Aspernatur aut tempora pariatur. Eveniet quia et rem sunt magni dolores consequatur aut. Vero nemo et dignissimos nobis eaque architecto consequatur. Harum eligendi consectetur aut facere harum ut maiores aliquid. Nisi reprehenderit est amet et rerum dolores sunt.",
                        new Guid("897e109d-f017-4823-9216-b38ae0ced709"), "Quia cum et."
                    },
                    {
                        new Guid("f5546526-0361-4313-96c0-7c0761ef2a80"),
                        "Velit corrupti cum quisquam consequatur expedita quia. Occaecati quo praesentium. Suscipit harum neque voluptatem commodi nulla dolorem et accusantium numquam. Aut illo sunt eius sunt perferendis quo voluptas quisquam et.\n\nFugit consectetur non enim facere fuga. Voluptatem dolores repellendus beatae. Ipsam consequatur nulla sed quasi officia velit culpa velit qui. Nam sint odio doloremque quae soluta officiis quod nemo. Ipsum ab architecto et provident esse dolorum pariatur.\n\nAspernatur reiciendis sed et vitae dolorem. Est magni et perferendis voluptatem provident qui ut. Ipsam deserunt consequuntur nisi fuga quae.",
                        new Guid("b8f25061-d6fa-441c-b846-5b8a8b7ad3bd"), "Incidunt qui a est assumenda sed quia culpa qui."
                    },
                    {
                        new Guid("bc478249-e0e1-4a06-a3be-796bc3d1fede"),
                        "Aperiam voluptas qui neque iste velit itaque quos vero enim. Porro nihil animi dolorem ducimus nemo earum. Amet quaerat aut consequuntur consequuntur maxime.\n\nAut recusandae ratione possimus soluta error modi fuga voluptatem. Et accusantium beatae ipsum. Alias dignissimos est vel sit sed non. Tempora nemo minus consequatur facilis inventore rerum animi.\n\nAutem molestiae iste. Iste debitis sequi sed aut aut enim ea. Voluptas perferendis id aut soluta occaecati recusandae corporis nostrum et. Et ducimus hic natus.",
                        new Guid("86d40d1a-6b49-434f-a145-abca7ec768b4"), "Error vel ut corrupti sapiente nihil et."
                    },
                    {
                        new Guid("2473f939-4b1f-44f2-b69b-92d6c301e46e"),
                        "Rerum qui distinctio voluptatibus natus. Ea dolorem qui voluptate doloribus et. A vitae atque. Dicta consequuntur suscipit temporibus odit non deserunt et velit. Assumenda repudiandae tenetur fuga est omnis. Quibusdam temporibus ad quia qui qui vel explicabo.\n\nSunt libero deleniti nihil praesentium consequatur velit. Sed et quas dolor quibusdam quasi ex. Voluptatibus quidem voluptates odio.\n\nMagni voluptate neque nostrum. Iusto ex qui occaecati. Illo iure sit a recusandae alias enim voluptates. Consequatur et ratione quia sit doloribus sed ut culpa. Dolor sit laborum omnis ea ut. Quaerat dolorem autem.",
                        new Guid("6ed539d4-5a74-4e0a-a2ac-aaeeac374ff5"), "Voluptatem reprehenderit odit consequatur est velit ab in eius."
                    },
                    {
                        new Guid("8d3acd59-14b0-431d-8d38-fdc7497960f3"),
                        "Velit autem eum amet distinctio consequatur accusamus. Deleniti velit error quas aliquam omnis maiores vitae. Amet iste error cumque sequi perspiciatis. Ut facere ab consectetur iste sed nam adipisci saepe. Recusandae est magnam ipsa consequatur iste tempore autem laudantium exercitationem.\n\nLabore sunt incidunt dicta. Dolor tenetur amet. Quaerat dolore sit eius et a cum fugit ea. Quis est nostrum voluptas suscipit eum aliquid. Repellat necessitatibus voluptates eligendi.\n\nFugiat excepturi voluptatum a. Aperiam corrupti et impedit ratione cum. Ut dolorem aspernatur animi asperiores cum.",
                        new Guid("d3b75333-7c71-4f7f-9072-fbf0700b3a42"), "Voluptas non cupiditate."
                    },
                    {
                        new Guid("e68ff636-551b-4ad2-8400-ab31bfb4b880"),
                        "Et laudantium porro quos aut repellat est quasi mollitia nobis. Accusamus nobis nam aperiam sapiente accusantium ducimus. Aut delectus sequi at. Qui pariatur quasi quo aut amet qui libero similique similique.\n\nVelit ab ea. Vero explicabo ratione ratione nulla consectetur vero necessitatibus nulla. Tenetur distinctio incidunt eius ut voluptatum laborum id tempore aperiam. Saepe voluptatem voluptate perspiciatis officiis ullam sed at voluptatibus omnis. Ipsa praesentium aliquam officiis consequatur nihil dolores et doloribus dolor. Eum ut deleniti odio ut mollitia suscipit dignissimos tempore.\n\nPariatur sapiente eum id animi. Saepe id aperiam et molestiae reiciendis et est delectus aspernatur. Et id quae ipsa placeat accusantium. Quia veritatis iusto tenetur cupiditate occaecati.",
                        new Guid("bd081703-2935-40d2-a3e5-c6022f2c469c"), "Debitis mollitia tempore est nostrum ipsa ut."
                    },
                    {
                        new Guid("06fbe178-8b6e-48b1-92fe-0295e330ed39"),
                        "Id aliquam ratione consequatur. Quaerat et nam vel et et. Quasi suscipit voluptas aut itaque qui error.\n\nItaque numquam sint quia unde vel rerum. Cum inventore sed et. Nemo temporibus id voluptatem doloremque repudiandae. Assumenda sunt voluptatem et. Aut voluptatem nisi.\n\nFacilis cumque similique fuga quibusdam. Et soluta at. Et et nihil dignissimos distinctio id et accusantium ut dolores. Consequatur et laboriosam assumenda consequatur adipisci eos voluptatem maxime sed. Expedita quia velit et ut illum excepturi.",
                        new Guid("9edb16e3-fa6b-4f52-94b4-3bd759585218"), "Aut laboriosam dolor aperiam ad enim et in asperiores."
                    },
                    {
                        new Guid("8f82be1e-b407-4589-b654-dc1ba49f044a"),
                        "Voluptatibus consequatur vel. Commodi fugit voluptatum quidem ad eaque ex magnam exercitationem. Repudiandae molestiae ipsa. Necessitatibus inventore tempore eveniet cupiditate eum occaecati porro. Assumenda laborum aperiam dolorem atque adipisci autem.\n\nIpsa vitae perferendis. Voluptatem voluptatibus ut maxime aliquam aut et repudiandae. Ut voluptatem commodi ex omnis quis dicta quis repellat. Facilis excepturi nihil accusantium et. Accusamus illo et ea.\n\nSapiente et numquam aperiam est distinctio. Magni rerum numquam est voluptatibus voluptatem quo laudantium magni. Consequatur laborum minus quae aut consequatur dolorem voluptatem. Asperiores sed eum dolorem culpa excepturi saepe sapiente ea minus. Occaecati soluta molestiae molestias. Quidem molestiae qui est omnis non maxime id velit.",
                        new Guid("b4fe2d01-ef6d-4cd2-ab72-a62afdfb3ced"),
                        "Autem neque laboriosam nesciunt quaerat quae porro minus libero et."
                    },
                    {
                        new Guid("cbc30111-de12-4a38-8f9c-aef608ad539c"),
                        "Praesentium tempore tenetur vero fugiat id quae non sapiente. Ducimus enim a. Sunt nobis id rerum exercitationem ut totam hic eum. Minima et velit. Minus vel eius asperiores nesciunt eaque ea sequi illum.\n\nEarum veritatis qui blanditiis praesentium sed. Soluta explicabo necessitatibus porro excepturi. Voluptate quos ea excepturi nostrum rerum in sed. Sed adipisci qui accusamus qui fugit. Quas recusandae accusamus possimus velit aliquid quia est dolores molestiae. Voluptates rerum odit tenetur perferendis et sunt qui nam.\n\nEt accusamus enim labore sed eos fuga accusamus officia. Aliquam omnis officia a pariatur possimus ducimus inventore voluptatem. Perferendis commodi qui nam aliquam ullam dolore dolor quisquam. Accusamus ducimus veniam et quasi. Atque sapiente illum enim voluptatem fuga laboriosam ab expedita amet.",
                        new Guid("513c52fc-48f2-436f-a31b-7a87974d1796"), "Repellat dolorem odit quia non ut aut."
                    },
                    {
                        new Guid("3ac42938-9525-4c36-b85c-7944604fbecf"),
                        "Soluta dolorum rerum non dolorem corporis modi qui. Officiis quia voluptatem minima officiis harum eum consequatur. Debitis omnis sapiente magnam.\n\nPraesentium impedit molestiae commodi voluptatem. Est tempore ut corrupti voluptates. Libero voluptas rerum tempora.\n\nDolorem molestiae quo quis officiis aut voluptatem in. Debitis voluptatem in omnis molestiae quis unde et. Debitis eos et nisi ratione provident. Temporibus delectus blanditiis.",
                        new Guid("bf26f744-2520-4cf9-b500-a243be8b3d5f"), "Ipsa velit et totam."
                    },
                    {
                        new Guid("cd7f94c5-1fba-4838-9809-6332d8652f2e"),
                        "Aut et sed incidunt doloribus dolorum aperiam. Magni pariatur veniam aspernatur qui nostrum. Vitae sed explicabo sed.\n\nQuo consequuntur consectetur recusandae vel. Cumque aperiam natus dolores. Explicabo impedit ut quidem et ipsam itaque.\n\nError architecto dolor corrupti. Fugiat rem et. Sunt rerum rerum. Veniam quae tempore non. Quia qui sit consequatur similique.",
                        new Guid("6a2ba0b2-7344-4164-8b41-c8477739ce18"), "Facere consequatur officiis placeat omnis."
                    },
                    {
                        new Guid("eefcdc5b-e7b1-4f3f-aaa2-4622c9583ae1"),
                        "Enim qui illo esse occaecati alias et corrupti. Qui sit autem ipsa magni est inventore maiores. Incidunt sed deserunt. Ullam et error. Explicabo deleniti aliquam ab ad.\n\nEt neque modi expedita soluta autem tempore. Consectetur in laborum deserunt iusto sed. Cupiditate nostrum magnam tenetur amet totam fugit ut explicabo.\n\nConsectetur voluptates omnis ut libero nemo nemo incidunt sed. Eum ea nemo enim natus nobis in rem nobis voluptatum. Autem quaerat a sapiente. Voluptatem voluptas explicabo consequatur saepe magni libero eum id. Tempore a et corporis veniam quia esse et eos. Rerum nobis fuga dolor quo quibusdam velit excepturi quisquam qui.",
                        new Guid("1e67be09-26ec-434d-bd4a-90588d726363"), "Et ad accusamus maiores laudantium eos enim architecto."
                    },
                    {
                        new Guid("c1093ac3-7dc5-4d42-9aad-79752cd45afd"),
                        "Facere veritatis voluptatem eum aliquam minima et aut et. Iure temporibus mollitia ut quis illo aliquam. Quia nesciunt qui debitis commodi qui non nulla sed qui.\n\nDelectus dolores impedit dolores qui eaque ullam nemo. Tempora non vero voluptatem sit. Vero ducimus recusandae nisi nobis.\n\nEt hic sed officiis optio. Dolorum velit beatae aut debitis explicabo facilis necessitatibus beatae. Non magnam possimus. Iste aspernatur rerum officiis est aperiam aspernatur aliquid qui ut. Perspiciatis aut laborum.",
                        new Guid("945f9679-5d2f-425f-958e-37195231b400"), "Omnis vel rerum laboriosam atque nobis."
                    },
                    {
                        new Guid("a030cb0d-6408-43c6-bfad-e05ee9be2696"),
                        "Alias est omnis natus voluptatibus. Ratione corporis consequatur totam. Ipsam nisi excepturi odio et distinctio esse eos quod. Fugit doloribus quod voluptatem. Consequatur nostrum culpa. Sunt commodi et at.\n\nVoluptatibus quibusdam iste quo aut et temporibus exercitationem quos beatae. Ullam quis dolor reprehenderit voluptatibus ex labore sit rerum. Eaque ullam earum eos vero est at eveniet.\n\nCorrupti voluptas excepturi facilis et eos voluptatem et minima voluptas. Magnam amet minima quasi alias quibusdam omnis deserunt. Adipisci libero exercitationem. Rerum dolores et reiciendis.",
                        new Guid("23c56966-d859-4234-a5f1-16c1cf5a0f66"), "Eos itaque in beatae adipisci."
                    },
                    {
                        new Guid("6bd10436-f556-4f35-8bfc-aa97bc879df6"),
                        "Assumenda rerum doloribus quaerat itaque velit. Rerum qui et dolor culpa nihil. Nulla dolorum dolores sed rerum. Cupiditate ut ab.\n\nUt maxime veritatis qui. Asperiores porro consequatur consequatur quia reiciendis iste. Iste et qui cupiditate minima ipsam saepe sit sapiente aspernatur. Rerum eaque molestiae fuga. Ut accusamus saepe quia. Deserunt libero laboriosam.\n\nRepudiandae laudantium in illo ab et et omnis natus sunt. Alias dolorum id rerum eius iure est sint dolor voluptatum. Sunt fugiat in suscipit dicta aliquid et. In aut laborum laboriosam in et odio et quae minima. Corrupti et ab adipisci delectus dolore nesciunt voluptatem et sed. Quam magni laudantium.",
                        new Guid("0d916615-c108-438d-9769-a1bbdf1558df"), "Quis quod et porro dolor."
                    },
                    {
                        new Guid("b1fa7557-2c6a-4d29-9163-11e72ae1d99d"),
                        "Deserunt quia quia iure minima suscipit blanditiis dolor. Animi rerum ut maiores cumque ipsa. Et dicta non doloremque sed omnis vel eum. Debitis illo inventore cumque magnam sit. Dolorem vero enim debitis sit in.\n\nEos voluptatem est quam dolor incidunt voluptatum facilis sit. Eius et at. Molestias eum autem temporibus voluptates ea minima in. Incidunt enim qui. Consequuntur molestiae neque dolorum vero sed odit dolorem. Eaque sapiente id.\n\nVelit est animi doloremque nihil rerum. Ut odio vitae tempora libero error. Laudantium earum quos ratione quidem dolores aliquid.",
                        new Guid("1c2d8a2e-7ce5-4dae-adca-59bc2ec1ef2e"), "Dolorem deleniti commodi molestias."
                    },
                    {
                        new Guid("97bfa951-386d-4fb4-84a6-fc25a62380ee"),
                        "Saepe quaerat id repellat tenetur exercitationem et similique. Repellendus eum reprehenderit deleniti porro facilis voluptas ipsa consequuntur ut. Dolorem recusandae mollitia cupiditate. Qui eveniet ut. Corrupti sit enim similique placeat et non. Quos nostrum esse et odit.\n\nOdio nihil quia ad doloremque est. Dicta fuga et natus sapiente distinctio non sint. In libero reiciendis excepturi voluptas architecto dolorem. Et et accusantium omnis quo atque ut veritatis.\n\nVitae quis ad dolorum. Illum voluptas recusandae nobis. Amet aut omnis dicta sunt minus perferendis sunt consequuntur. Nobis consequatur aut reprehenderit dolorum mollitia maxime dolorem dolore eos. Et iusto sint consequuntur perspiciatis veniam omnis laudantium neque maxime.",
                        new Guid("76daf81c-3401-49fa-8d8f-dd28082ad75e"),
                        "Iure veritatis perspiciatis omnis aut earum reiciendis odit totam."
                    },
                    {
                        new Guid("c8fdda2a-e0f5-4232-8bb7-d1c5fe479c3b"),
                        "Labore et aut iusto. Ab tempora vero molestiae nulla. Commodi aut voluptas quia voluptas eum doloremque nesciunt et. Excepturi temporibus occaecati in amet dolorum et et quas.\n\nAb error debitis quibusdam facilis rerum dolores qui consequatur. Vitae et quia reiciendis quasi enim tenetur molestiae atque perspiciatis. Assumenda consequatur est perferendis quos eos sunt molestiae neque. Molestiae tempora eveniet enim perspiciatis. Cupiditate adipisci dolores saepe impedit quos nulla molestiae rerum ipsam.\n\nUt aut quasi. Quasi eaque veniam. Sequi repellendus sequi voluptatem. Voluptatem nulla id. Soluta nemo libero non.",
                        new Guid("a66edcbd-3f2d-4fc4-bec1-9b781e617602"), "Et incidunt doloribus et quia ad."
                    },
                    {
                        new Guid("6aaa811e-247e-4e18-ba9a-76c4625195c1"),
                        "Magni quia ut reiciendis beatae. Veniam et sequi. Doloremque ut qui quod eaque rem pariatur nobis est. Enim sed consequatur non. Sapiente soluta voluptas doloremque quam repudiandae aut.\n\nExpedita reiciendis possimus quasi earum quibusdam voluptatem magnam cupiditate. Quidem sit expedita eligendi consectetur sint. Odio fuga minima accusantium molestiae ipsum suscipit iure sed. Dignissimos debitis minus hic sit. Accusamus vitae inventore porro dolor quod at sint.\n\nIste nostrum voluptate nemo doloribus est sint dolorum. Eum qui fugiat qui consequatur quam. Dolorem nihil debitis autem temporibus et et excepturi.",
                        new Guid("438ac187-2627-4547-a76f-474ceb07e384"), "Est magni quibusdam sit cumque est commodi consequatur dolore."
                    },
                    {
                        new Guid("f4a7ed6b-4e13-43f2-8b54-50e46eb9906a"),
                        "Quidem quia dicta ullam ex qui doloribus quia quia. Modi quia dolorem earum. Mollitia velit laudantium temporibus facilis. Nam porro minus fuga sed rem. Et hic possimus.\n\nDolorem autem facilis. Praesentium quia perferendis placeat nostrum deserunt est itaque. Doloribus voluptatem cumque quia. Quia qui aspernatur ea ut praesentium ex.\n\nQuaerat saepe quia autem. A ab nisi ratione optio a. Nostrum est saepe quia quasi aut autem laudantium. Voluptatem reprehenderit cum esse. Vel accusantium quam qui amet minima repellendus.",
                        new Guid("939d2a92-79b3-45f3-bc93-b6dd3961eadb"), "Possimus vero delectus."
                    },
                    {
                        new Guid("7d712355-5a07-4a65-9d0a-e5e9fa7f3d00"),
                        "Molestiae vel sapiente aliquam. Eius quos est qui quia veritatis nobis et. Debitis unde mollitia ab autem ipsam reprehenderit. Accusamus quia ex.\n\nQuis qui quia doloremque labore vitae blanditiis qui omnis. Est maiores sint quo et sapiente alias facilis iusto. Atque autem corporis reiciendis vel officiis. Quibusdam aut molestias quidem. At nihil sed perspiciatis architecto sunt dolorem id est dolor. Possimus accusamus veritatis.\n\nRatione neque accusamus soluta sint qui nemo. Voluptas nisi eius commodi recusandae expedita et ut sequi dolorem. Dolores molestias cumque necessitatibus. Illum eum assumenda nihil ad perspiciatis aut placeat esse unde.",
                        new Guid("615c0cd9-0114-4b27-a61f-33b45ffa2a66"), "Rerum rerum tenetur voluptatibus in sed nostrum nihil."
                    },
                    {
                        new Guid("873f5a7a-5066-4c6a-ac45-6829f4837e11"),
                        "Qui est voluptatibus ut laborum dignissimos voluptatem. Aut consequatur voluptatum itaque rerum. Ad atque labore consequatur minus reprehenderit accusantium sunt aut. Repellendus magnam perferendis. Quia laboriosam aut ea qui similique ut. Reiciendis culpa optio culpa rem ab dolorem nulla impedit culpa.\n\nFugiat rerum quis laboriosam voluptatem. Rem rerum animi repudiandae qui commodi. Ut fugit perspiciatis impedit architecto sed.\n\nIn molestias distinctio enim sequi et reiciendis. Neque ea quia eos cumque omnis sed ab omnis aliquam. Explicabo et ad et consequuntur suscipit. Recusandae recusandae fuga eos.",
                        new Guid("701bacf8-9a38-46c2-9a2d-2a518d02608f"), "Laudantium autem est iusto magni et doloremque repellat."
                    },
                    {
                        new Guid("2228fd8d-ae1f-48b0-b43d-b3a66b2dcf20"),
                        "Aut voluptatibus inventore est. Dolor aliquid voluptate sunt molestiae expedita. Ut alias et ratione nam porro ut perferendis consequatur. Sit asperiores doloremque. Ipsam quisquam culpa voluptates enim voluptatem. Hic quo necessitatibus libero nisi harum sunt.\n\nSapiente et dignissimos vel laudantium possimus dolores quibusdam cum. Quam earum suscipit veritatis est et distinctio alias laudantium. Dolorem sit et qui sed sit dolorem aliquid.\n\nVitae optio ut hic vitae. Unde numquam repellat natus qui dolor incidunt quas. Expedita et est et id soluta harum odit esse. Dolor sapiente quae.",
                        new Guid("2f731a78-1a72-4f83-bb9f-9ce39d05a859"), "Dignissimos deserunt dolor voluptatem ex est quisquam."
                    },
                    {
                        new Guid("8fde0cfc-12cb-4059-abee-24f18254f9a2"),
                        "Voluptatum nam et perferendis dignissimos error eum consectetur. Vel qui qui architecto at quidem numquam ipsam explicabo aspernatur. Sequi odit quia aut accusamus nobis eaque ipsam. Et aut temporibus aut sequi totam sit dolorem voluptas.\n\nAccusantium quia quibusdam perferendis. Voluptatibus velit perferendis aliquid magnam. Eius aut sed culpa quis blanditiis est qui omnis. Et quis at ad id itaque sint.\n\nReprehenderit unde eum et est eum nemo. Vero necessitatibus atque accusantium. Similique et rerum illum nisi sunt aspernatur natus dolores fuga. Impedit sapiente tenetur earum quod est ipsa.",
                        new Guid("b5494f6d-b3c3-4576-a440-5b6f3538b69b"), "Et id eos ad iure."
                    },
                    {
                        new Guid("e7dbcd77-e8e1-46da-b043-f7a1e63d08cd"),
                        "Et delectus nihil sit quis praesentium minus quia. Soluta eum consequatur laborum natus unde rem. Qui id occaecati iure aut. Quia eaque quidem similique est delectus voluptatem dolorum. Quisquam est nobis assumenda non id quia molestias facere nemo.\n\nNon assumenda ullam architecto cumque ipsum dolore similique. Fugit voluptatem reprehenderit voluptas eum. Est necessitatibus ipsa non molestiae inventore at sunt consequatur debitis. Earum libero id tempora assumenda vitae quis et autem. Laboriosam dolores doloribus autem et.\n\nId quis nostrum dignissimos ratione et voluptatum. Impedit explicabo enim cum cum cum nostrum. Et incidunt in sapiente.",
                        new Guid("76652a41-c159-4590-8ad0-98b0a844cc5e"), "Ut labore sit quam."
                    },
                    {
                        new Guid("c17d7065-da36-4f6a-a52f-e05ee929b082"),
                        "Minus laboriosam hic assumenda. Illum vero eaque sit. Eum suscipit nesciunt magni. Et itaque ea iure qui laudantium tenetur dicta aliquid accusamus.\n\nAut possimus fuga quaerat et harum sequi voluptatem similique aut. Quod voluptas vel non ut. Iusto et rerum sunt non voluptatem. Quidem fugiat nam libero dolor magnam. Eveniet neque non maxime veniam nihil eveniet. Nihil consequatur accusamus molestiae.\n\nEt unde quia recusandae id tempore sint quasi. Ipsam sit id ut fuga. Delectus atque deleniti ipsam esse ea.",
                        new Guid("3a32c61a-af7c-4c26-9a56-a069af5559b5"),
                        "Repudiandae quidem dolore rerum occaecati exercitationem aspernatur."
                    },
                    {
                        new Guid("fb597145-39f3-4a19-9ecb-82b256342813"),
                        "Veritatis ex aperiam et ex quia voluptatem voluptatem. Odio eius et impedit voluptatem sequi voluptas. Qui ratione eos laudantium. Quia sed ea et consectetur. Voluptatibus consectetur aut perferendis rerum et.\n\nMollitia molestiae et accusantium occaecati voluptatem. Quia delectus iusto labore rem quam aliquam hic provident totam. Tempora quod ratione repudiandae sint vero magni.\n\nVoluptatem sit sed. Quia voluptatibus omnis. Et sint sed dolorum. Dignissimos alias voluptatem ut. Porro quae qui et culpa.",
                        new Guid("c76d26b6-af93-4bf0-95ac-d99f64fbe450"), "Laboriosam ad exercitationem dolore nobis repudiandae est."
                    },
                    {
                        new Guid("7ecc1486-7593-4b40-a082-13c089a3c557"),
                        "Consequatur sit voluptatem et in ad omnis odit sit. Aperiam omnis et. Provident voluptates architecto facilis sit est nemo excepturi.\n\nIn nam ut. Sunt quasi praesentium quisquam similique ut earum aperiam. Accusantium et fugiat culpa consequatur. Est impedit hic delectus ut autem.\n\nDignissimos maxime laudantium qui dolores aut veritatis voluptas minus minus. Sed voluptatem et enim. Saepe cumque dolores natus.",
                        new Guid("3846483b-cd9c-47f0-a2eb-ae7f103fa905"), "Ea amet adipisci."
                    },
                    {
                        new Guid("b78f50da-aa4c-4074-b194-55c16002d7d4"),
                        "Est vel et. Sunt pariatur rem magni sit reiciendis aut dicta. Voluptatem quis optio molestias aspernatur dignissimos. Eos aspernatur qui possimus quasi enim.\n\nNecessitatibus ipsa natus enim voluptatem iure nesciunt. Cumque aperiam neque quis et magni laborum suscipit. Aut aliquam nisi. Aliquid saepe dicta facere eum.\n\nVoluptatibus officiis et ullam unde non et. Quam fugiat itaque veritatis doloribus id repellat voluptatum recusandae nesciunt. Aut corrupti veritatis nam ut sit. Ut sed ratione rem sint quia quam sed optio eum. Eos id dolores necessitatibus quidem sint. Accusamus adipisci aliquid tempore ex.",
                        new Guid("3696b5a3-8270-442d-bebe-3726ea0234a8"), "Voluptatem deserunt quam a dolores et."
                    },
                    {
                        new Guid("5a40df06-eb09-420e-93af-208051b4e76e"),
                        "Nesciunt perspiciatis nulla est. Ut cumque dolorem reiciendis placeat sed doloremque doloribus laborum. Recusandae molestiae dolores sapiente ipsam sit omnis. Vero velit molestias molestiae. Odit a est rerum neque ut est in. Excepturi veniam voluptas tempora voluptatum.\n\nMagni laboriosam in id ipsum quasi ducimus magnam. Non quia in quis doloribus sunt magnam. Sapiente porro sit accusantium quaerat et rerum rerum sit fuga.\n\nHarum dicta ut error. Qui vero non est similique aperiam excepturi. Ex harum qui voluptas doloremque voluptatem. Doloremque velit ut possimus dolor dolorum accusamus rem itaque pariatur. Dignissimos provident ipsa a dignissimos nam fugiat voluptas voluptatem quo. Tempora qui nobis molestias iste.",
                        new Guid("f3c562c7-ea04-4ac8-979c-b4c6b501ff44"),
                        "Incidunt et natus voluptatem nemo reiciendis dolor modi qui repellendus."
                    },
                    {
                        new Guid("1a937d3e-d1f8-43fb-aa3f-77f31c988160"),
                        "Architecto ea ut ut ut laboriosam fugiat ducimus et quae. Praesentium vel sint sit quo. Earum vitae dignissimos. Ullam nostrum qui.\n\nQui odit delectus sit facere qui commodi voluptas. Sit quia aut aut quia iste. Aut vel dolorem libero. Asperiores quibusdam nisi sed. Consequatur asperiores qui est et ut et debitis. Qui atque ipsum exercitationem.\n\nAut aspernatur enim. Sit recusandae debitis necessitatibus officiis nostrum voluptatum. Ut occaecati ratione enim fuga non illo reprehenderit consequatur sit. Tenetur quidem rerum magni aut dolorem maxime voluptas. Et sunt ipsum eveniet atque et aspernatur. Magni odit hic atque officia quidem eum ex ab.",
                        new Guid("9fced0c7-8cb4-44cd-8e42-e8d2da434616"), "Vero a labore excepturi qui tenetur."
                    },
                    {
                        new Guid("ecdd1a1b-0cca-459a-9199-561ec119587f"),
                        "Ut architecto et et veritatis. Qui a reiciendis distinctio. Magnam dolorem qui fugit nostrum. Voluptatem quasi neque commodi repellat.\n\nSapiente voluptate necessitatibus aut minima voluptate nulla numquam ducimus. Ut accusantium delectus. Ipsa qui doloremque harum distinctio.\n\nEt deserunt aperiam. Hic aliquam laudantium aut quis asperiores et a accusantium. Expedita ut similique cum sunt illum dolores et nihil et.",
                        new Guid("93dbf2ea-dff0-453f-9a25-614d2793c878"), "Voluptas asperiores eius."
                    },
                    {
                        new Guid("d5d98639-7f97-466c-b946-54294c8233de"),
                        "Voluptatibus recusandae sint dignissimos consequatur et. Quae hic voluptatem. Unde in reprehenderit aut debitis rerum qui. Omnis repudiandae ullam facere et animi omnis. Et praesentium debitis illum quia soluta incidunt autem nemo dicta. Fuga sed consequatur doloribus.\n\nDolores et quae velit libero dignissimos porro labore dolores. Rem soluta sit sit voluptas blanditiis. Et qui architecto suscipit molestiae et ipsum animi et temporibus. Dolorem iure amet molestiae rem itaque. Sed molestias voluptas. Sit nesciunt culpa doloribus.\n\nFugit consequuntur quasi qui dolorem voluptatem consequuntur ea possimus. Et sed officiis animi accusamus et. Velit maxime ut perspiciatis non. Perferendis nemo hic ipsum.",
                        new Guid("f3cec9bc-ce15-4d6e-8902-a3cf32e4c02c"), "Error repudiandae possimus."
                    },
                    {
                        new Guid("3301516a-8b04-4016-8989-8a4b47e25c6d"),
                        "Cumque est quibusdam sed. Aut ipsa aspernatur est debitis est voluptates sint soluta dolorem. Aspernatur accusantium quisquam pariatur.\n\nQuia rerum omnis. Reprehenderit accusamus ut. At veniam aliquam ex eligendi in mollitia dolor facilis dolore. Cupiditate odio saepe molestias ut. Explicabo animi in architecto omnis consequatur. Qui est deleniti repudiandae.\n\nCorrupti quia et est accusantium odio et neque maiores. Ut voluptatem eum voluptatum unde quaerat laborum. Autem cupiditate nobis ullam enim. Aut ullam ad aspernatur sapiente quae aspernatur nobis consequatur. Possimus consequuntur expedita temporibus et quasi qui minima aut. Vero possimus ipsum.",
                        new Guid("64ca72c9-67b2-4feb-a079-4ad1f570f4a8"), "Est dolores aperiam neque sed magnam eos."
                    },
                    {
                        new Guid("4e179fed-dc79-4050-96c5-e6b35e229607"),
                        "Omnis eos non sed suscipit est et natus repellat repellendus. Nam autem at. Sunt corporis voluptate nobis illum aperiam minima optio consequatur dolore. Autem eos reprehenderit.\n\nDoloribus alias aut tempora. Ut rem tempore qui omnis id ut nesciunt. Hic sit in numquam nulla explicabo. Excepturi praesentium itaque dolores odio nesciunt officiis quis.\n\nDolorem cumque et sed distinctio est et ut vero. Minus aspernatur illo exercitationem quae sed voluptatibus exercitationem eos. Et perspiciatis sed dolores deleniti perspiciatis dolorem qui eius architecto.",
                        new Guid("36307fbd-3c7f-498a-9e17-46f195467330"), "Eum ex asperiores similique provident perspiciatis ut."
                    },
                    {
                        new Guid("9c11b76c-d824-42fd-90e3-f50054c92f7f"),
                        "Reiciendis aut est quia. Neque quibusdam repudiandae. Sed veniam ut ut natus numquam rerum odit.\n\nA debitis qui accusantium et quia excepturi soluta. Enim sit eaque sequi pariatur recusandae illum aliquid natus reiciendis. Sint et quidem eos qui eos. Voluptas porro similique architecto et ea voluptatem quaerat corporis quo.\n\nPariatur dolores atque voluptas facilis distinctio dolorem magni. Esse maxime eos. Consequuntur aut magni nisi labore consequatur.",
                        new Guid("5d30bb95-a9c4-4c92-872a-6e1692cb918e"), "Repellendus ea tempore sapiente."
                    },
                    {
                        new Guid("0e049dc4-1cae-4e95-b18f-2c1c424a4c11"),
                        "Porro iusto omnis dolore tempora qui. In quos rerum illum quod modi a quia odio. Aut consequatur maiores ipsa exercitationem voluptatem est. Ut reiciendis laboriosam ea nihil minus quaerat at. Voluptates quo sint aut aut quam ipsum.\n\nAdipisci qui quisquam similique. Ipsam eligendi explicabo illo asperiores sed qui nihil esse. Quas debitis placeat nihil quia et numquam iste rerum. Ab veniam molestiae et et qui illum.\n\nEum et sit dolor. Accusantium quo sit cum. Voluptatem voluptatem atque nihil est. Incidunt libero maxime sit quasi reiciendis. Quo earum quo aperiam assumenda.",
                        new Guid("0906f966-515b-4598-9626-04803c8c7fd2"), "Consectetur voluptate porro voluptas voluptatem qui."
                    },
                    {
                        new Guid("c20f278c-c27d-4d4a-94e9-5eef1d6428f3"),
                        "Commodi cum fugiat officia. Reiciendis voluptatem quo magni saepe doloremque omnis asperiores. Et aut accusamus nihil ut impedit. Cupiditate dolore consectetur sint et fugiat aut earum.\n\nOccaecati praesentium ducimus exercitationem corrupti exercitationem praesentium repellendus assumenda. Perspiciatis repellat eius aspernatur error et non. Omnis sed dolore doloribus cum quas voluptas. Facilis tempore error ratione eum eveniet.\n\nExcepturi ipsam perspiciatis. Dolorem quo voluptate quidem. Aut ratione non doloremque. Aliquid qui corporis. Neque voluptates in non dolor.",
                        new Guid("917ef761-36c5-491d-93f1-91f2604ed0d2"),
                        "Blanditiis inventore et temporibus modi dolorum numquam est enim ratione."
                    },
                    {
                        new Guid("67c23adf-4c2b-4734-bf6f-eb1c53b03f40"),
                        "Perspiciatis minus ab eos quae aliquam vero. Illo veniam sed sed commodi reprehenderit dicta quae dolorem ipsa. Voluptatem reprehenderit itaque ad ea. Sequi dolorem animi error odio. Est voluptas cumque omnis ad non ipsam. Necessitatibus architecto molestiae cum exercitationem voluptatem aut sed repellat recusandae.\n\nIllo voluptates quas voluptatem id praesentium facilis pariatur necessitatibus. Quaerat voluptatem et placeat vel ex. Et consequatur sint excepturi consequuntur rem amet laudantium. Reiciendis aliquam dolor dolorum eum.\n\nAnimi atque vel voluptatem omnis. Illum aut totam voluptatem. Illum est veritatis unde suscipit facere. Vel consequuntur assumenda voluptas molestiae iusto ipsam nobis nisi. Reprehenderit tempore enim animi mollitia ipsa.",
                        new Guid("d5c89d53-ba33-45c0-b4eb-91764c56810e"), "Voluptatem repellat explicabo."
                    },
                    {
                        new Guid("d0138dcc-457c-4342-8621-d8dc4a98f6b6"),
                        "Asperiores harum quae aut aut quis. Velit et sint nihil maxime ducimus sed molestias enim. Vel hic et eum laboriosam quos autem.\n\nEius similique quae veniam laboriosam distinctio voluptas itaque magni. Minima dolorem nihil earum. Ratione quae voluptatum dolore cupiditate voluptatem inventore provident maxime. Dolorum ratione et et et qui magnam aliquid. Sequi quis voluptatem ratione. Omnis voluptatibus excepturi voluptate autem doloribus qui.\n\nAperiam soluta exercitationem. Unde tempora impedit. Aperiam corporis sunt porro. Occaecati quia deleniti asperiores doloremque voluptatum enim. Ut asperiores eveniet saepe atque ut rerum et nesciunt. Reiciendis libero eos quia recusandae ea quia nihil quia.",
                        new Guid("18b89c40-be9d-44e9-ae5d-e2b95bc7d271"), "Asperiores magnam pariatur in eos dolore."
                    },
                    {
                        new Guid("c84923d3-aac7-4f5f-ac49-cce4a257c3b7"),
                        "Explicabo sed in laudantium id sed. Error voluptatum error vero ut. Harum repudiandae architecto et sunt. Facilis sit quo et doloribus earum necessitatibus corrupti vero. Eum modi quo assumenda saepe dolores dolores. Quisquam sit dignissimos ut ad.\n\nDolor sed neque iste. Facilis voluptatem ipsum minus ad corporis. Eaque voluptate occaecati pariatur quae. A sunt nisi sit laudantium eum.\n\nEst dolor possimus voluptate tempore et quis aliquid vel. Est recusandae commodi sapiente sed ab. Quos officia debitis. Earum sed atque.",
                        new Guid("e17912ef-bcc9-4f2a-86e5-8f682f40ab39"), "Sed voluptatem autem aut nesciunt quasi."
                    },
                    {
                        new Guid("86b57677-c27e-454f-9e9f-2aeb804269f1"),
                        "Voluptatem et ipsum. Fuga laboriosam facere sunt pariatur cupiditate quo quo deleniti. Sed optio quos aliquid qui sed dolorem dolor corporis. Vitae voluptas similique labore.\n\nEt non qui ut ab ab eveniet dolorum. Occaecati soluta assumenda exercitationem aut. Beatae atque est quae. Impedit corporis sit quia quaerat. Adipisci delectus facere dolor est sint ut.\n\nEt voluptatem dolores. Et et accusamus aspernatur non occaecati illo atque exercitationem. Consequatur ex sint consectetur quia ut adipisci repudiandae voluptas dicta.",
                        new Guid("61d59e69-1179-4f51-8b1e-befd5239e17b"), "Vero non accusamus rem placeat dolorem accusamus."
                    },
                    {
                        new Guid("a57b35fe-621c-4589-a70a-41be0ee71b47"),
                        "Minima iste officiis omnis ipsam doloremque quos expedita aut. Sit aliquid maiores dicta. Ratione omnis perspiciatis mollitia velit. Ipsam beatae facere expedita dolor recusandae nobis excepturi. Rerum quod eius repellendus eos rerum consequuntur. Expedita tempora tempora iure porro explicabo.\n\nAliquid consectetur repellat aut. Consequatur quia atque adipisci delectus deleniti quia odit provident aspernatur. Ratione qui voluptatem ad magni velit modi esse sit. Rerum consequatur sit magnam mollitia. Consectetur laudantium molestiae maxime est velit quidem occaecati similique minus.\n\nEa consequatur veniam quia magni nihil et voluptatem fugiat quis. Voluptatem delectus culpa. Unde atque aut. Rerum consequatur dolores non rerum. Ex fugit minus.",
                        new Guid("aa6a18e4-aa44-42c2-897f-06865a4a6b45"), "Maxime impedit qui laborum quia aut perferendis dicta omnis."
                    },
                    {
                        new Guid("52d7f495-c51a-4a4d-ba2a-bac4b924ceb7"),
                        "Veniam mollitia nam nihil eum. Ipsam laborum facilis blanditiis et ipsum quasi architecto quam enim. At qui voluptate.\n\nAnimi deserunt sit est quia et ut praesentium in. Dolorum eaque in qui rem amet consequatur ut earum. Omnis eveniet voluptas amet ut. Quia voluptatem voluptas.\n\nEt sapiente praesentium asperiores quasi cupiditate aut fuga reprehenderit. Sit illo magni unde aperiam dolores minima et. Quae quia laudantium ratione enim nihil eum asperiores autem et. Facere et sed repellat qui architecto sed ratione ea.",
                        new Guid("8dafb046-60df-48ca-bfc5-69db91b77aa9"), "Nihil ut omnis ut consequatur voluptas quidem quidem."
                    },
                    {
                        new Guid("f8c763a9-3fdb-4bba-828f-9efd7a6070f7"),
                        "Saepe aliquid voluptates ut id suscipit illum. Quis et non qui. Rerum sapiente similique recusandae magni qui. Vel magni qui enim nisi dolorem repudiandae id et eos.\n\nInventore distinctio vero ea impedit. Qui corrupti quaerat non vero neque dolores reiciendis delectus voluptates. Quibusdam et molestias et ea sed omnis.\n\nSaepe omnis quam non minima nihil ab dolorem. Porro repellendus iste eos ab id et cumque. Ad ut dolores commodi vero consequatur. Aut tenetur nobis. Cumque praesentium aspernatur qui quasi doloribus. Et quae est et aut delectus enim.",
                        new Guid("5c9ba41a-20db-4bbe-b2f8-56502f6d763b"), "Consequuntur accusantium itaque vero."
                    },
                    {
                        new Guid("e10d4fe5-719c-4565-b606-5e548b8f09b4"),
                        "Expedita facere corrupti porro quas non sint velit. Ipsum rem consequatur quo. Quaerat est odit temporibus veritatis quia quia expedita et voluptas. Dolorem illo laborum aut. Ipsum aspernatur repudiandae temporibus ipsa nihil est minus similique praesentium. Et vero voluptatum sapiente quod aliquam nisi doloribus.\n\nVoluptatem autem est corrupti alias tenetur est deserunt suscipit voluptatum. Provident amet alias quis blanditiis. Et omnis beatae quis modi id nihil occaecati quibusdam quia. Eum repudiandae quo dolorum dignissimos vitae voluptatem nemo voluptatem corporis.\n\nSapiente qui ut maiores iure quia libero voluptatum deserunt. Sit nihil iusto ea perspiciatis. Consectetur tempora delectus quia et est quia quam omnis nobis.",
                        new Guid("dc6c6e75-3910-4d53-808a-10730fd08536"), "Odit reiciendis veritatis."
                    },
                    {
                        new Guid("d462547d-dcb9-4987-b360-c45d8f1db2ee"),
                        "Vero iure asperiores quo culpa deserunt voluptatibus et qui consectetur. Quos amet inventore modi impedit sit. Architecto libero veritatis delectus et iusto nostrum fugiat eos. Eos id dolorum debitis ducimus non ea.\n\nIure illum explicabo non quia. Ipsa voluptatem quasi delectus magnam possimus rem. Hic quo porro. Saepe ratione iste unde maxime qui molestiae similique expedita.\n\nQuae aliquam et saepe vel autem illo. Qui itaque qui velit esse modi accusamus necessitatibus autem reprehenderit. Libero neque qui dicta excepturi sit est voluptas. Rerum aspernatur iste. Rem nihil voluptatem impedit mollitia eos explicabo dolore eveniet.",
                        new Guid("428c4b8d-b75a-4859-b7b9-af4429122d0b"), "In et odio rerum qui voluptas officiis error."
                    },
                    {
                        new Guid("121ac50a-d6cf-4029-964c-bddeb78d38fd"),
                        "Sapiente eveniet iusto ipsam. Eos quo id hic. Laboriosam ipsa eum animi qui doloribus velit neque nostrum non. Ducimus est et sequi dolor. Labore et sint.\n\nLaudantium autem necessitatibus. Maiores impedit sed blanditiis voluptatem corrupti exercitationem. Qui provident cupiditate quo numquam voluptatem consequuntur quo enim cumque.\n\nConsequuntur consequatur nesciunt asperiores et rem reiciendis. Repellendus voluptatem in aut impedit nesciunt. Corrupti fuga fugiat. Consequatur sequi vero aperiam dolorum expedita ut voluptatem voluptatum. Atque aut omnis quos vel dignissimos. Unde perspiciatis iure cum molestias eos magni magni a excepturi.",
                        new Guid("11ab7803-35ff-408b-a885-0c5116cfc7ea"), "Illo ratione quidem dicta."
                    },
                    {
                        new Guid("68336fb6-e178-47c8-ae4e-796b842195fe"),
                        "Cumque ut eum veritatis. Laborum repellendus similique ex. Ea omnis voluptatem maxime nulla. Minus omnis dolores. Sed animi est odit veritatis et velit qui saepe et.\n\nEt aut quia tenetur rerum aspernatur dolor delectus quod numquam. Qui expedita aspernatur rem deleniti est neque. Provident et id quo aspernatur fuga minima alias molestias velit.\n\nVero explicabo occaecati ab numquam dolorum saepe odit. Asperiores provident et voluptatem aut culpa qui sapiente. Recusandae consequatur minus culpa.",
                        new Guid("2f9a86c1-4d64-4fe2-a7a7-8b5b2e2feaa4"),
                        "Incidunt eveniet reprehenderit voluptatem voluptas libero explicabo enim."
                    },
                    {
                        new Guid("d37c9fe2-b97b-4c88-ad62-e66517cfb046"),
                        "Quo sint atque. Voluptas animi in rerum est deserunt. Consequuntur fugit quasi. Aut nostrum repudiandae aut quibusdam dolorum nobis dolor culpa ad. Eos qui repellat. Et laboriosam rerum debitis est quae quidem.\n\nNecessitatibus consectetur asperiores ea ut dicta ea veniam totam. Ea sint et aspernatur voluptatibus. Doloremque eos et eos ipsam laudantium. Necessitatibus ratione earum est dolor ut quam hic suscipit. Eos vitae id et veniam iusto quos repudiandae.\n\nQuaerat mollitia doloremque velit labore sapiente odio dolorum. Minus et praesentium molestiae vel aut quaerat voluptate enim dolor. Ab autem et. Odit sit autem consequatur placeat cumque velit modi officia. Omnis exercitationem fugit non sed eius quibusdam et ipsa.",
                        new Guid("a5a283ae-9490-4891-8924-bd62f4379802"), "Voluptatem cum et tempora cupiditate voluptatem accusantium."
                    }
                });

            migrationBuilder.CreateIndex(
                "IX_Products_ProductTypeId",
                "Products",
                "ProductTypeId");

            migrationBuilder.CreateIndex(
                "IX_Reviews_ProductId",
                "Reviews",
                "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Reviews");

            migrationBuilder.DropTable(
                "Products");

            migrationBuilder.DropTable(
                "ProductTypes");
        }
    }
}