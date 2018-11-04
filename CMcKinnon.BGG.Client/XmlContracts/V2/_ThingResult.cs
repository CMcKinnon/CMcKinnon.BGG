using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client.XmlContracts.V2
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "items")]
    public class _ThingResult : _XmlContractBase
    {

    }
}
