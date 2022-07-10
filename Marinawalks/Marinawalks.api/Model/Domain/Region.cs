namespace Marinawalks.api.Model.Domain
{
    public class Region
    {
        //Create first property,short hand is prop and tab
        public Guid Id { get; set; }

        public  string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public double Population { get; set; }

        //Navigation Property

        //Every region is related to walks,one region can have multiple walks

        //Below statement tells entity framework that one region can have multiple walks
        public IEnumerable <Walk> Walks { get; set; }




    }
}
