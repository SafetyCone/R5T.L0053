using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IXElementOperator : IFunctionalityMarker
    {
        public void Add_BeforeElementEndTag(
            XElement element,
            object content)
        {
            var lastNodeOrDefault = element.LastNode;

            var isDefault = lastNodeOrDefault == default;
            if(isDefault)
            {
                element.Add(content);
            }
            else
            {
                lastNodeOrDefault.AddAfterSelf(content);
            }
        }

        /// <summary>
        /// Creates a separate, but identical instance.
        /// <para>Same as <see cref="Deep_Copy(XElement)"/></para>
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Documentation.WhichXObjectsAreCloneable" path="/summary"/>
        /// </remarks>
        public XElement Clone(XElement element)
        {
            // Use the constructor.
            var output = new XElement(element);
            return output;
        }

        public XElement Clone_OnlyName(XElement element)
        {
            var output = new XElement(element.Name);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Parse(string, LoadOptions)"/>.
        /// </summary>
        public XElement Create_Element(
            string xmlText, 
            LoadOptions loadOptions = ILoadOptionsSets.Default_Constant)
        {
            var output = this.Parse(
                xmlText,
                loadOptions);

            return output;
        }

        /// <summary>
        /// Creates a copy of the element, and all child-nodes.
        /// <para>Same as <see cref="Clone(XElement)"/></para>
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Documentation.WhichXObjectsAreCloneable" path="/summary"/>
        /// </remarks>
        public XElement Deep_Copy(XElement element)
        {
            return this.Clone(element);
        }

        public IEnumerable<XElement> Enumerate_ChildElements(XElement element)
        {
            var output = element.Elements();
            return output;
        }

        public IEnumerable<XNode> Enumerate_ChildNodes(XElement element)
        {
            var output = element.Nodes();
            return output;
        }

        public IEnumerable<TNode> Enumerate_ChildNodesOfType<TNode>(XElement element)
            where TNode : XNode
        {
            var output = this.Enumerate_ChildNodes(element)
                .OfType<TNode>()
                ;

            return output;
        }

        public IEnumerable<XNode> Enumerate_DescendantNodes(XElement element)
        {
            var output = element.DescendantNodes();
            return output;
        }

        public IEnumerable<TNode> Enumerate_DescendantNodesOfType<TNode>(XElement element)
            where TNode : XNode
        {
            var output = this.Enumerate_DescendantNodes(element)
                .OfType<TNode>()
                ;

            return output;
        }

        public XElement[] Get_ChildElements(XElement element)
        {
            var output = this.Enumerate_ChildElements(element)
                .Now();

            return output;
        }

        public XNode[] Get_ChildNodes(XElement element)
        {
            var output = this.Enumerate_ChildNodes(element)
                .Now();

            return output;
        }

        public TNode[] Get_ChildNodesOfType<TNode>(XElement element)
            where TNode : XNode
        {
            var output = this.Enumerate_ChildNodesOfType<TNode>(element)
                .Now();

            return output;
        }

        public TNode[] Get_DescendantNodesOfType<TNode>(XElement element)
            where TNode : XNode
        {
            var output = this.Enumerate_DescendantNodesOfType<TNode>(element)
                .Now();

            return output;
        }

        public XElement Parse(
            string xmlText,
            LoadOptions loadOptions = ILoadOptionsSets.Default_Constant)
        {
            var output = XElement.Parse(
                xmlText,
                loadOptions);

            return output;
        }

        public string To_Text(
            XElement xElement,
            XmlWriterSettings writerSettings)
        {
            var stringBuilder = new StringBuilder();

            using (var xmlWriter = XmlWriter.Create(stringBuilder, writerSettings))
            {
                xElement.WriteTo(xmlWriter);
            }

            var output = stringBuilder.ToString();
            return output;
        }

        /// <summary>
        /// It can be hard to get a text representation of an XElement that shows the XElement exactly as it is, without modifications.
        /// (For example, if the indent XML writer setting is set to true, then you will get extra text output that is not present as XText nodes in the element.)
        /// </summary>
        public string To_Text_NoModifications(XElement xElement)
        {
            var writerSettings = Instances.XmlWriterSettingsSets.Standard;

            writerSettings.Indent = false;
            writerSettings.NewLineHandling = NewLineHandling.None;
            writerSettings.ConformanceLevel = ConformanceLevel.Fragment;

            var output = this.To_Text(
                xElement,
                writerSettings);

            return output;
        }
    }
}
