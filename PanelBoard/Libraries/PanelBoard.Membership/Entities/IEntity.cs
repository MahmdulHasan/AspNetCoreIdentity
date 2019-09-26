using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Membership.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
