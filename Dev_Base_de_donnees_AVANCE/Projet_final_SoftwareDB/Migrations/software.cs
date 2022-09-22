using MySql.Data.MySqlClient;

namespace Migrations;

public class software
{
    public static void migrate(MySqlConnection conn)
    {
        MySqlCommand createTable = new MySqlCommand(@"
            CREATE TABLE if not exists `software` (
            `id` int PRIMARY KEY,
            `softwareName` varchar(20),
            `OsSupported` varchar(25),
            `priceFee` varchar(30),
            `description` text,
            `openSource` boolean,
            `idOwner` varchar(100),
            `idCategory` int,
            `IsDeleted` BIT NOT NULL DEFAULT 0,
            foreign key (idOwner) references owner(idOwner),
            foreign key (idCategory) references category(idCategory));", conn);
        createTable.ExecuteNonQuery();
    }

    public static void rollback(MySqlConnection conn)
    {
        MySqlCommand deleteTable = new MySqlCommand("drop table if exists software;", conn);
        deleteTable.ExecuteNonQuery();
    }
    
    public static void seed(MySqlConnection conn)
    {
        MySqlCommand insertInto = new MySqlCommand(@"
            insert into software value(1, 'Gong', '[Windows][macOS][Linux]', 'priced per recorded user','Gong captures and analyzes customer interactions and alerts you to risks and opportunities across your business',false,'Amit Bendov',2,0);
            insert into software value(2, 'Simplenote', '[Windows][macOS][Linux]', 'free','The simplest way to keep notes',true,'Automattic',9,0);
            insert into software value(3, 'Zendesk', 'webApp', 'month billed annually','Zendesk provides the complete customer service solution that’s easy to use and scales with your business',false,'Mikkel Svane - CEO & Founder',8,0);
            insert into software value(4, 'Amplitude Analytics', 'webApp', 'free to custom price','Behavioral Analytics Platform for Product Intelligence',false,'Spenser Skates',2,0);
            insert into software value(5, 'Chorus', 'webApp', 'priced per recorded user','Backed by 16 technology patents that leverage proprietary machine-learning, Chorus is the fastest growing Conversation Intelligence product in existence.',false,'Roy Raanani',1,0);
            insert into software value(6, 'Confluence', 'webApp', 'free to custom price','Confluence is a collaboration wiki tool used to help teams to collaborate and share knowledge efficiently',false,'Atlassian.inc',10,0);
            insert into software value(7, 'Visual Studio', '[Windows][macOS][Linux]', 'free','What do you want to [code, build, debug, deploy, collaborate on, analyze, learn] today? Visual Studio can do that',false,'Microsoft.inc',5,0);
            insert into software value(8, 'Apollo.io', 'webApp', 'free to professional price','Apollo.io is a lead intelligence and sales engagement platform trusted by nearly 9,000 paying customers',false, 'Tim Zheng - Founder',6,0);
            insert into software value(9, 'Sendoso', 'webApp', 'custom price','Sendoso, the leading Sending Platform, is the most effective way to connect with customers and drive revenue with personalized gifts, branded swag, eGifts, virtual experiences, and more',false,'Kris Rudeegraap',4,0);
            insert into software value(10, 'Salesloft', 'webApp', 'custom price','Salesloft is the provider of the leading sales engagement platform that helps sellers and sales teams drive more revenue. The Modern Revenue Workspace™ by Salesloft is the one place for sellers to execute all of their digital selling tasks, communicate with buyers, understand what to do next, and get the coaching and insights they need to win. ',false,'Kyle Porter',3,0);
            insert into software value(11, 'GIMP', '[Windows][macOS][Linux]', 'free','Outil dedition et de retouche dimage, diffusé sous la licence GPLv3 comme un logiciel gratuit et libre',true,'none',11,0);
            insert into software value(12, 'Chorus', 'webApp', 'priced per recorded user','Backed by 16 technology patents that leverage proprietary machine-learning, Chorus is the fastest growing Conversation Intelligence product in existence.',false,'Roy Raanani',1,0);
            insert into software value(13, 'Confluence', 'webApp', 'free to custom price','Confluence is a collaboration wiki tool used to help teams to collaborate and share knowledge efficiently',false,'Atlassian.inc',10,0);
            insert into software value(14, 'Visual Studio', '[Windows][macOS][Linux]', 'free','What do you want to [code, build, debug, deploy, collaborate on, analyze, learn] today? Visual Studio can do that',false,'Microsoft.inc',5,0);
            insert into software value(15, 'Apollo.io', 'webApp', 'free to professional price','Apollo.io is a lead intelligence and sales engagement platform trusted by nearly 9,000 paying customers',false, 'Tim Zheng - Founder',6,0);
            insert into software value(16, 'Gong', '[Windows][macOS][Linux]', 'priced per recorded user','Gong captures and analyzes customer interactions and alerts you to risks and opportunities across your business',false,'Amit Bendov',2,0);
            insert into software value(17, 'Simplenote', '[Windows][macOS][Linux]', 'free','The simplest way to keep notes',true,'Automattic',9,0);
            insert into software value(18, 'Zendesk', 'webApp', 'month billed annually','Zendesk provides the complete customer service solution that’s easy to use and scales with your business',false,'Mikkel Svane - CEO & Founder',8,0);
            insert into software value(19, 'Amplitude Analytics', 'webApp', 'free to custom price','Behavioral Analytics Platform for Product Intelligence',false,'Spenser Skates',2,0);
            insert into software value(20, 'Chorus', 'webApp', 'priced per recorded user','Backed by 16 technology patents that leverage proprietary machine-learning, Chorus is the fastest growing Conversation Intelligence product in existence.',false,'Roy Raanani',1,0);
            insert into software value(21, 'Apollo.io', 'webApp', 'free to professional price','Apollo.io is a lead intelligence and sales engagement platform trusted by nearly 9,000 paying customers',false, 'Tim Zheng - Founder',6,0);
            insert into software value(22, 'Sendoso', 'webApp', 'custom price','Sendoso, the leading Sending Platform, is the most effective way to connect with customers and drive revenue with personalized gifts, branded swag, eGifts, virtual experiences, and more',false,'Kris Rudeegraap',4,0);
            insert into software value(23, 'Salesloft', 'webApp', 'custom price','Salesloft is the provider of the leading sales engagement platform that helps sellers and sales teams drive more revenue. The Modern Revenue Workspace™ by Salesloft is the one place for sellers to execute all of their digital selling tasks, communicate with buyers, understand what to do next, and get the coaching and insights they need to win. ',false,'Kyle Porter',3,0);
            insert into software value(24, 'Gong', '[Windows][macOS][Linux]', 'priced per recorded user','Gong captures and analyzes customer interactions and alerts you to risks and opportunities across your business',false,'Amit Bendov',2,0);
            insert into software value(25, 'Simplenote', '[Windows][macOS][Linux]', 'free','The simplest way to keep notes',true,'Automattic',9,0);
            insert into software value(26, 'Zendesk', 'webApp', 'month billed annually','Zendesk provides the complete customer service solution that’s easy to use and scales with your business',false,'Mikkel Svane - CEO & Founder',8,0);
            insert into software value(27, 'Amplitude Analytics', 'webApp', 'free to custom price','Behavioral Analytics Platform for Product Intelligence',false,'Spenser Skates',2,0);
            insert into software value(28, 'Chorus', 'webApp', 'priced per recorded user','Backed by 16 technology patents that leverage proprietary machine-learning, Chorus is the fastest growing Conversation Intelligence product in existence.',false,'Roy Raanani',1,0);
            insert into software value(29, 'Confluence', 'webApp', 'free to custom price','Confluence is a collaboration wiki tool used to help teams to collaborate and share knowledge efficiently',false,'Atlassian.inc',10,0);
            insert into software value(30, 'Visual Studio', '[Windows][macOS][Linux]', 'free','What do you want to [code, build, debug, deploy, collaborate on, analyze, learn] today? Visual Studio can do that',false,'Microsoft.inc',5,0);
            ",conn);
            insertInto.ExecuteNonQuery();
            
    }

    
}
