
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/21/2015 21:48:09
-- Generated from EDMX file: C:\Users\Syed\Documents\Visual Studio 2013\Projects\RestaurantManagementSystem\RestaurantManagementSystem\Models\Oasis.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OasisRestaurant];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__OrderDeta__Drink__2E1BDC42]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderDetails] DROP CONSTRAINT [FK__OrderDeta__Drink__2E1BDC42];
GO
IF OBJECT_ID(N'[dbo].[FK__OrderDeta__FoodI__2D27B809]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderDetails] DROP CONSTRAINT [FK__OrderDeta__FoodI__2D27B809];
GO
IF OBJECT_ID(N'[dbo].[FK__OrderDeta__Order__2C3393D0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderDetails] DROP CONSTRAINT [FK__OrderDeta__Order__2C3393D0];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO
IF OBJECT_ID(N'[dbo].[DeliveryDriverInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeliveryDriverInfo];
GO
IF OBJECT_ID(N'[dbo].[Drink]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Drink];
GO
IF OBJECT_ID(N'[dbo].[Feeds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Feeds];
GO
IF OBJECT_ID(N'[dbo].[Food]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Food];
GO
IF OBJECT_ID(N'[dbo].[FoodType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FoodType];
GO
IF OBJECT_ID(N'[dbo].[Location]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Location];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[OrderDelivery]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderDelivery];
GO
IF OBJECT_ID(N'[dbo].[OrderDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderDetails];
GO
IF OBJECT_ID(N'[dbo].[OrderStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderStatus];
GO
IF OBJECT_ID(N'[dbo].[Store]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Store];
GO
IF OBJECT_ID(N'[dbo].[UserAdmin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserAdmin];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerID] uniqueidentifier  NOT NULL,
    [CustomerName] nvarchar(500)  NULL,
    [Address1] nvarchar(100)  NULL,
    [Address2] nvarchar(100)  NULL,
    [PhoneNumber] nvarchar(12)  NULL
);
GO

-- Creating table 'DeliveryDriverInfoes'
CREATE TABLE [dbo].[DeliveryDriverInfoes] (
    [DeliveryVanID] uniqueidentifier  NOT NULL,
    [DeliveryDriverPersonName] nvarchar(100)  NULL,
    [DeliveryVehicleID] nvarchar(1000)  NULL
);
GO

-- Creating table 'Drinks'
CREATE TABLE [dbo].[Drinks] (
    [DrinkID] uniqueidentifier  NOT NULL,
    [DrinkName] nvarchar(50)  NULL,
    [Notes] nvarchar(1000)  NULL
);
GO

-- Creating table 'Feeds'
CREATE TABLE [dbo].[Feeds] (
    [FeedID] uniqueidentifier  NOT NULL,
    [FeedDescription] nvarchar(1000)  NULL,
    [FeedDateTime] datetime  NULL
);
GO

-- Creating table 'Foods'
CREATE TABLE [dbo].[Foods] (
    [FoodID] uniqueidentifier  NOT NULL,
    [FoodName] nvarchar(50)  NULL,
    [Notes] nvarchar(1000)  NULL,
    [Price] decimal(12,2)  NULL,
    [DiscountPrice] decimal(12,2)  NULL,
    [FoodTypeID] uniqueidentifier  NULL
);
GO

-- Creating table 'FoodTypes'
CREATE TABLE [dbo].[FoodTypes] (
    [FoodTypeID] uniqueidentifier  NOT NULL,
    [FoodTypeName] nvarchar(50)  NULL
);
GO

-- Creating table 'Locations'
CREATE TABLE [dbo].[Locations] (
    [LocationID] uniqueidentifier  NOT NULL,
    [LocationName] nvarchar(500)  NULL,
    [LocationZipCode] nvarchar(11)  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderID] uniqueidentifier  NOT NULL,
    [OrderDescription] nvarchar(500)  NULL,
    [OrderDateTime] datetime  NULL,
    [OrderPerson] nvarchar(500)  NULL,
    [DeliveryAddress] nvarchar(1000)  NULL,
    [OrderPersonPhone] nvarchar(13)  NULL,
    [OrderOriginalPrice] decimal(12,2)  NULL,
    [OrderStatusID] uniqueidentifier  NULL,
    [OrderDiscountedPrice] decimal(12,2)  NULL
);
GO

-- Creating table 'OrderDeliveries'
CREATE TABLE [dbo].[OrderDeliveries] (
    [OrderDeliveryID] uniqueidentifier  NOT NULL,
    [OrderID] uniqueidentifier  NULL,
    [DeliveryID] uniqueidentifier  NULL
);
GO

-- Creating table 'OrderDetails'
CREATE TABLE [dbo].[OrderDetails] (
    [OrderDetailID] uniqueidentifier  NOT NULL,
    [OrderID] uniqueidentifier  NOT NULL,
    [FoodID] uniqueidentifier  NOT NULL,
    [DrinkID] uniqueidentifier  NOT NULL,
    [Notes] nvarchar(1000)  NULL
);
GO

-- Creating table 'OrderStatus'
CREATE TABLE [dbo].[OrderStatus] (
    [OrderStatusID] uniqueidentifier  NOT NULL,
    [OrderStatusName] nvarchar(100)  NULL
);
GO

-- Creating table 'Stores'
CREATE TABLE [dbo].[Stores] (
    [StoreID] uniqueidentifier  NOT NULL,
    [StoreName] nvarchar(500)  NULL,
    [State] nvarchar(100)  NULL,
    [City] nvarchar(100)  NULL
);
GO

-- Creating table 'UserAdmins'
CREATE TABLE [dbo].[UserAdmins] (
    [UserID] uniqueidentifier  NOT NULL,
    [UserName] nvarchar(500)  NULL,
    [Pwd] nvarchar(100)  NULL,
    [StoreID] uniqueidentifier  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CustomerID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerID] ASC);
GO

-- Creating primary key on [DeliveryVanID] in table 'DeliveryDriverInfoes'
ALTER TABLE [dbo].[DeliveryDriverInfoes]
ADD CONSTRAINT [PK_DeliveryDriverInfoes]
    PRIMARY KEY CLUSTERED ([DeliveryVanID] ASC);
GO

-- Creating primary key on [DrinkID] in table 'Drinks'
ALTER TABLE [dbo].[Drinks]
ADD CONSTRAINT [PK_Drinks]
    PRIMARY KEY CLUSTERED ([DrinkID] ASC);
GO

-- Creating primary key on [FeedID] in table 'Feeds'
ALTER TABLE [dbo].[Feeds]
ADD CONSTRAINT [PK_Feeds]
    PRIMARY KEY CLUSTERED ([FeedID] ASC);
GO

-- Creating primary key on [FoodID] in table 'Foods'
ALTER TABLE [dbo].[Foods]
ADD CONSTRAINT [PK_Foods]
    PRIMARY KEY CLUSTERED ([FoodID] ASC);
GO

-- Creating primary key on [FoodTypeID] in table 'FoodTypes'
ALTER TABLE [dbo].[FoodTypes]
ADD CONSTRAINT [PK_FoodTypes]
    PRIMARY KEY CLUSTERED ([FoodTypeID] ASC);
GO

-- Creating primary key on [LocationID] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [PK_Locations]
    PRIMARY KEY CLUSTERED ([LocationID] ASC);
GO

-- Creating primary key on [OrderID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- Creating primary key on [OrderDeliveryID] in table 'OrderDeliveries'
ALTER TABLE [dbo].[OrderDeliveries]
ADD CONSTRAINT [PK_OrderDeliveries]
    PRIMARY KEY CLUSTERED ([OrderDeliveryID] ASC);
GO

-- Creating primary key on [OrderDetailID] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [PK_OrderDetails]
    PRIMARY KEY CLUSTERED ([OrderDetailID] ASC);
GO

-- Creating primary key on [OrderStatusID] in table 'OrderStatus'
ALTER TABLE [dbo].[OrderStatus]
ADD CONSTRAINT [PK_OrderStatus]
    PRIMARY KEY CLUSTERED ([OrderStatusID] ASC);
GO

-- Creating primary key on [StoreID] in table 'Stores'
ALTER TABLE [dbo].[Stores]
ADD CONSTRAINT [PK_Stores]
    PRIMARY KEY CLUSTERED ([StoreID] ASC);
GO

-- Creating primary key on [UserID] in table 'UserAdmins'
ALTER TABLE [dbo].[UserAdmins]
ADD CONSTRAINT [PK_UserAdmins]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DrinkID] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [FK__OrderDeta__Drink__2E1BDC42]
    FOREIGN KEY ([DrinkID])
    REFERENCES [dbo].[Drinks]
        ([DrinkID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__OrderDeta__Drink__2E1BDC42'
CREATE INDEX [IX_FK__OrderDeta__Drink__2E1BDC42]
ON [dbo].[OrderDetails]
    ([DrinkID]);
GO

-- Creating foreign key on [FoodID] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [FK__OrderDeta__FoodI__2D27B809]
    FOREIGN KEY ([FoodID])
    REFERENCES [dbo].[Foods]
        ([FoodID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__OrderDeta__FoodI__2D27B809'
CREATE INDEX [IX_FK__OrderDeta__FoodI__2D27B809]
ON [dbo].[OrderDetails]
    ([FoodID]);
GO

-- Creating foreign key on [OrderID] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [FK__OrderDeta__Order__2C3393D0]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[Orders]
        ([OrderID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__OrderDeta__Order__2C3393D0'
CREATE INDEX [IX_FK__OrderDeta__Order__2C3393D0]
ON [dbo].[OrderDetails]
    ([OrderID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------