namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FAVORITOS
    {
        public int Id { get; set; }

        public int IdUser { get; set; }

        public int IdArticulo { get; set; }
    }
}
