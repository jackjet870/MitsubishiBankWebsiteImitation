namespace MitsubishiBankWebsiteImitation
{
    /*
     * Final project of 2nd year based on Microsoft .NET and ASP.NET MVC\WebAPI2 Frameworks. 
     * It uses following technologies : 
     * .NET, C#, ASP.NET MVC, ASP.NET WebAPI2, Entity Framework ORM, MS SQL Database, Raven NoSQL Database.
     * For front-end it uses Bootstrap by Twitter.
     */
    class Domain
    {
        class Core
        {
            //Business Logic Layer
        }

        class Interfaces
        {
            //Interfaces to implement : 
            //Repository and Control level interfaces
        }
    }

    class Infrastucture
    {
        class Business
        {
            /*
             * Implementation of Services Interface
             */
        }

        class Data : Interfaces
        {
            /*
             * Implementation of Repository Interface
             */
        }
    }

    class Services
    {
        class Interfaces
        {
            /*
             * IServices to implement 
             */
        }

        class Listener // Refactor
        {
            
        }
    }

    class TestSection
    {
        class MVC
        {
            
        }

        class WebAPI
        {
            
        }
    }

    class PresentationLayer
    {
        
    }

}