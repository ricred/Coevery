﻿using Orchard.ContentManagement.MetaData;
using Orchard.Data.Migration;

namespace Futures.Widgets.DataMigrations {
    public class WidgetsDataMigration : DataMigrationImpl {

        public int Create() {
            //CREATE TABLE Futures_Widgets_HasWidgetsRecord (Id INTEGER not null, primary key (Id));
            SchemaBuilder.CreateTable("HasWidgetsRecord", table => table
                .Column<int>("Id", column => column.PrimaryKey())
                );

            //CREATE TABLE Futures_Widgets_WidgetRecord (Id INTEGER not null, Zone TEXT, Position TEXT, Scope_id INTEGER, primary key (Id));
            SchemaBuilder.CreateTable("WidgetRecord", table => table
                .ContentPartRecord()
                .Column<string>("Zone")
                .Column<string>("Position")
                .Column<int>("Scope_id")
                );

            return 1;
        }

        public int UpdateFrom1() {
            ContentDefinitionManager.AlterTypeDefinition("Site",
                cfg => cfg
                    .WithPart("HasWidgets")
                );

            ContentDefinitionManager.AlterTypeDefinition("HtmlWidget",
                cfg => cfg
                    .WithPart("Widget")
                    .WithPart("BodyAspect")
                );

            return 2;
        }
    }
}