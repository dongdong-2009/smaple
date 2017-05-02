/*******************************************************************************
	
    Javascript objects and some utilities to create web page 
    organization charts.
    Please refer to the html sample file
    
    created by Roland Bouman
    Copyright (C) 2006  
    R_P_Bouman@hotmail.com
    http://rpbouman.blogspot.com/

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA

*******************************************************************************/

/*******************************************************************************
*
*	UTILITIES
*
*
*******************************************************************************/
/*
*	void toggleChildNodes(DOMNode)
*	
*	purpose:
*		Shows or hides the children of an OrganizationChartNode, depending on it's state
*	arguments:
*		DOMNode: the toggleElement of the OrganizationChartNode 
*	returns:
*		nothing
*	usage:
*		used to handle the onclick event on the toggleelement of a OrganizationChartNode
*/
	function toggleChildNodes(node)
	{
		var childNodesDiv = node.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.nextSibling;
		while (childNodesDiv.nodeType!=1)
		{
			childNodesDiv = childNodesDiv.nextSibling;
		}
		switch (node.innerHTML)
		{
			case "+":
				node.innerHTML = "-";
				childNodesDiv.style.display = "";
				break;
			case "-":
				node.innerHTML = "+";
				childNodesDiv.style.display = "none";
				break;
		}
	}
/*
*	DOMElement getFirstChildElement(DOMElement)
*
*	purpose:
*		returns the first child element from an element
*	arguments:
*		DOMNode: the element for which the first child element is to be returned
*	returns:
*		The first child element of the the argument element, or null if there is none
*	usage:
*		Utility used internally to navigate through a OrganizationNode fragment
*/
	function getFirstChildElement(node){
		var childNodes = node.childNodes;
		var index = 0;
		var countChildNodes = childNodes.length;
		do {
			if (index>=countChildNodes)
			{
				node = null;
				break;
			}
		} while ((node = childNodes.item(index++)).nodeType!=1);
		return node;
	}
/**
*	OrganizationChartNode getOrganizationChartNode(DOMNode)
*
*	purpose:
*		returns the OrganizationChartNode instance for a arbitrary node in a OrganizationChartNode fragement
*	arguments:
*		DOMNode: a node belonging to an OrganizationChartNode fragment.
*	returns:
*		The OrganizationChartNode instance, if there is one, and else null.
*	usage:
*		Utility used internally to navigate through a OrganizationNode fragment
*
*/
	function getOrganizationChartNode(node)
	{
		var organizationChartNode = null;
		do{
			if (node.className=="CSS_NODE")
			{
				organizationChartNode = node.organizationChartNode;
				break;
			}							
		} while ((node =  node.parentNode)!=null);
		return organizationChartNode; 
	}
/*******************************************************************************
*
*	PRIVATE
*
*
*******************************************************************************/
/*
*	TBody OrganizationChartNode.getParentTBody()
*
*	purpose:
*		find the table body that contains the connections to the parent node
*	arguments:
*		none
*	returns:
*		the tablebody element
*	usage:
*		used internally to navigate through a OrganizationChartNode fragment
*/
	OrganizationChartNode.prototype.getParentTBody= function()
	{
		return this.domEquivalent.tBodies[0];
	}
/*
*	TBody OrganizationChartNode.getParentTBody()
*
*	purpose:
*		find the table body that contains the node proper
*	arguments:
*		none
*	returns:
*		the tablebody element
*	usage:
*		used internally to navigate through a OrganizationChartNode fragment
*/
	OrganizationChartNode.prototype.getBoxTBody= function()
	{
		return this.domEquivalent.tBodies[1];
	}
/*
*	Table OrganizationChartNode.getBox()
*
*	purpose:
*		find the table that represents the node proper
*	arguments:
*		none
*	returns:
*		the table element
*	usage:
*		used internally to navigate through a OrganizationChartNode fragment
*/
	OrganizationChartNode.prototype.getBox= function()
	{
		var node;
		node = this.getBoxTBody();
		node = node.rows[0];
		node = node.cells[1];
		return getFirstChildElement(node);
	}
/*
*	td OrganizationChartNode.getLabelElement()
*
*	purpose:
*		find the table cell that represents the node label
*	arguments:
*		none
*	returns:
*		the table cell element
*	usage:
*		used internally to navigate through a OrganizationChartNode fragment
*/
	OrganizationChartNode.prototype.getLabelElement = function()
	{
		var node = this.getBox();
		node = node.rows[0];
		return node.cells[0];				
	}
/*
*	tr OrganizationChartNode.getChildrenRow()
*
*	purpose:
*		findd the body row that contains info on the childnodes
*	arguments:
*		none
*	returns:
*		the table row
*	usage:
*		used internally to navigate through the fragment
*
*/
	OrganizationChartNode.prototype.getChildrenRow = function()
	{
		var node = this.getBox();
		return node.rows[1];
	}

/*
*	td OrganizationChartNode.getToggleElement()
*
*	purpose:
*		get the element that is used to expand/collapse the childnodes
*	arguments:
*		none
*	returns:
*		the table cell that is used as toggle switch
*	usage:
*		used internally to maintain state
*
*/
	OrganizationChartNode.prototype.getToggleElement = function()
	{
		var node = this.getChildrenRow();
		return node.cells[0];
	}
/*
*	td OrganizationChartNode.getChildCountElement()
*
*	purpose:
*		get the element that is used to present the number of childnodes to the user
*	arguments:
*		none
*	returns:
*		the table cell that is used to present the number of children
*	usage:
*		used internally to maintain state
*
*/
	OrganizationChartNode.prototype.getChildCountElement = function()
	{
		var node = this.getChildrenRow();
		return node.cells[1];
	}
/*
*	void OrganizationChartNode.setChildCount(childCount)
*
*	purpose:
*		updates the childcount presentation. 
*	arguments:
*		childCount: integer representing the number of children
*	returns:
*		nothing
*	usage:
*		used internally to maintain state
*
*/
	OrganizationChartNode.prototype.setChildCount = function(childCount)
	{
		var node = this.getChildCountElement();
		node.innerHTML = childCount;
	}
/*
*	tbody OrganizationChartNode.getChildrenTBody()
*
*	purpose:
*		returns the table body that contains the children of this node.
*	arguments:
*		none
*	returns:
*		the table body that contains the children
*	usage:
*		used internally to navigate through a fragment
*
*/
	OrganizationChartNode.prototype.getChildrenTBody = function()
	{
		return this.domEquivalent.tBodies[2];
	}
/*
*	tr OrganizationChartNode.getChildrenContainer()
*
*	purpose:
*		returns the table row that contains the cells that contain the children
*	arguments:
*		none
*	returns:
*		the table body that contains the children
*	usage:
*		used internally to navigate through a fragment
*
*/
	OrganizationChartNode.prototype.getChildrenContainer= function()
	{
		var node;
		node = this.getChildrenTBody();
		node = node.rows[1];
		node = node.cells[0];
		
		return getFirstChildElement(node).rows[0];
	}
/*
*	void OrganizationChartNode.prototype.renderAttachmentToParent()
*
*	purpose:
*		draws the nodes connections to it's parent node
*	arguments:
*		none
*	returns:
*		nothing
*	usage:
*		used internally to redraw when a node changes parent
*
*/			
	OrganizationChartNode.prototype.renderAttachmentToParent = function()
	{
		var parentTBody = this.getParentTBody();
		var parentNode = this.domEquivalent.parentNode;
		if (parentNode==null)
		{
			this.parentTBody.style.display="none";
		} 
		else if (
			parentNode.tagName=="TD"
		&&	parentNode.className=="CSS_NODE_CHILD"
		)
		{
			parentTBody.style.display = "";
			var parentRow = parentTBody.rows[0];			
			var siblingCount = parentNode.parentNode.cells.length;
			//opera.postError("parentNode: " + parentNode);
			//opera.postError("cellIndex: " + parentNode.cellIndex);
			if(parentNode.cellIndex==0)
			{
				parentRow.cells[0].className = "CSS_FLANK";
				parentRow.cells[1].className = "CSS_VSTICKR";
			} 
			else 
			{
				parentRow.cells[0].className = "CSS_FLANK CSS_HSTICK";
				parentRow.cells[1].className = "CSS_VSTICKR CSS_HSTICK";
			}
		
			if (parentNode.cellIndex==(siblingCount-1))
			{
				parentRow.cells[2].className = "CSS_VSTICKL";
				parentRow.cells[3].className = "CSS_FLANK";
			} 
			else
			{
				parentRow.cells[2].className = "CSS_VSTICKL CSS_HSTICK";
				parentRow.cells[3].className = "CSS_FLANK CSS_HSTICK";
			}
				
		} 
		else 
		{
			parentTBody.style.display="none";
		}
	}			
/*******************************************************************************
*
*	PUBLIC
*
*
*******************************************************************************/
/**
*	OrganizationChartNode OrganizationChartNode(label)
*
*	purpose:
*		Constructor. Creates a new OrganizationChartNode 
*	arguments:
*		label: a string used as label for the node
*	returns:
*		The new OrganizationChartNode instance.
*	usage:
*		instantiate new nodes
*		var hqNode = new OrganizationChartNode("HQ");
*
*/
	function OrganizationChartNode(text,value,func)
	{
		var organizationChartNodeTemplate = document.getElementById(
			"OrganizationCharNodeTemplate"
		);
		this.domEquivalent = organizationChartNodeTemplate.cloneNode(true);
		this.domEquivalent.organizationChartNode = this;
		this.setLabelHTML(text,value,func);
//		this.onclick = function(args){}
		return this;
	}
/**
*	
*
*/
OrganizationChartNode.prototype.STATE_COLLAPSED = "+";
OrganizationChartNode.prototype.STATE_EXPANDED = "-";
OrganizationChartNode.prototype.enableToggle = 'false';

/**
*	void OrganizationChartNode.addToContainer(container)
*
*	purpose:
*		Add an OrganizationChartNode instance to an existing dom element
*	arguments:
*		label: a string used as label for the node
*	returns:
*		The new OrganizationChartNode instance.
*	usage:
*		instantiate new nodes
*		var hqNode = new OrganizationChartNode("HQ");
*
*/
	OrganizationChartNode.prototype.addToContainer = function(container)
	{
		if (
			container.className!="CSS_NODE_CHILD"
		&&	container.tagName!="TD"					
		)
		{
			this.getParentTBody().style.display="none";
		}
		container.appendChild(this.domEquivalent);
	}
/*
*	void OrganizationChartNode.prototype.removeFromContainer()
*
*	purpose:
*		detaches a node form it's container
*	arguments:
*		none
*	returns:
*		nothing
*	usage:
*		used to modify the hierarchy
*
*/			
	OrganizationChartNode.prototype.removeFromContainer = function()
	{
		var parentNode = this.domEquivalent.parentNode;
		if (parentNode==null)
		{
			return;
		} else {					
			var cellIndex = parentNode.cellIndex;
			parentNode.removeChild(this.domEquivalent);
			if (
				parentNode.tagName=="TD"
			&&	parentNode.className=="CSS_NODE_CHILD"
			){	
				var row = parentNode.parentNode
				var cells = row.cells;
				row.removeChild(parentNode)
				var countChildNodes = cells.length;
				var organizationChartNode = getOrganizationChartNode(row);
				organizationChartNode.setChildCount(countChildNodes);
				if (countChildNodes!=1)
				{
					if(cellIndex==0)
					{
						getFirstChildElement(
							cells[0]
						).organizationChartNode.renderAttachmentToParent();
					} else if (cellIndex==countChildNodes)
					{
						getFirstChildElement(
							cells[countChildNodes-1]
						).organizationChartNode.renderAttachmentToParent();
					}
				}
			}
		}
	}
/**
*	boolean OrganizationChartNode.isRootNode()
*
*	purpose:
*		Determine if the OrganizationChartNode instance is the root of a hierarchy
*	arguments:
*		none
*	returns:
*		true if the instance is topmost OrganizationChartNode instance, false otherwise
*	usage:
*		used internally to navigate through the hierarchy
*		if (organizationChartNodeInstance.isRootNode()){
*			//do stuff
*		}
*
*/
	OrganizationChartNode.prototype.isRootNode = function()
	{
		var parentNode = this.domEquivalent.parentNode;
		if (parentNode==null)
		{
			return true;
		}
		if (parentNode.nodeType==1)
		{
			if (
				parentNode.tagName=="TD"
			&&	parentNode.className=="CSS_NODE_CHILD"
			) {
				return false;
			} 
		}
		return true;
	}
/*
*	OrganizationChartNode getParentNode()
*
*	purpose:
*		Get the OrganizationChartNode instance that is parent of the current OrganizationChartNode
*	arguments:
*		none
*	returns:
*		the OrganizationChartNode that is parent, or null if this is a root node
*	usage:
*		used internally to navigate through the hierarchy
*/			
	OrganizationChartNode.prototype.getParentNode = function()
	{
		if (this.isRootNode())
		{
			return null;
		}
		var parentDomEquivalent =  this.domEquivalent.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
		return parentDomEquivalent.organizationChartNode;
	}
/*
*	void OrganizationChartNode.setLabelHTML(htmlString)
*
*	purpose:
*		sets the contents of the node label
*	arguments:
*		text: the (html) text to be placed inside the label element. 
*       value:
*	returns:
*		nothing
*	usage:
*		modify the label text:
*
*		organizationChartNode.setLabelHTML("new name","new id");
*/
	OrganizationChartNode.prototype.setLabelHTML = function(text,value,func)
	{
		var labelElement = this.getLabelElement();
		
		if(func)
		{
		    labelElement.style.cursor='pointer';
		    var temp = function()
		    {		        
		        eval(func+"("+value+");");
		        
		    }
		    if(labelElement.addEventListener)
		    {		    
		        labelElement.addEventListener("click",temp,false);  //ff
		    }
		    else
		    {
		        labelElement.attachEvent("onclick",temp,false); //ie
		    }
		    labelElement.innerHTML = "<span onmouseover ='this.style.textDecoration = \"underline\"' onmouseout=' this.style.textDecoration = \"none\"'  >" + text + "</span>";
		}
		else
		{
		    labelElement.innerHTML =  text ;
		}
	}
	
/*
*	void OrganizationChartNode.getState()
*
*	目的:
*		returns wheter the children are displayed.
*	参数:
*		none
*	返回值:
*		a string, 
*			"+" if collapsed (children hidden), 
*			"-" if expanded (children visible)
*	用途:
*		used internally to maintain state
*
*/



/*
*	void OrganizationChartNode.getState()
*
*	purpose:
*		returns wheter the children are displayed.
*	arguments:
*		none
*	returns:
*		a string, 
*			"+" if collapsed (children hidden), 
*			"-" if expanded (children visible)
*	usage:
*		used internally to maintain state
*
*/
	OrganizationChartNode.prototype.getState = function()
	{
		var node = this.getToggleElement();
		return node.innerHTML;
	}
/*
*	void OrganizationChartNode.setState(state)
*
*	purpose:
*		sets the state, and expands or collapses the childeren
*	arguments:
*		state, one of 
*			OrganizationChartNode.prototype.STATE_COLLAPSED
*			OrganizationChartNode.prototype.STATE_EXPANDED
*	returns:
*		nothing
*	usage:
*		
*
*/
	OrganizationChartNode.prototype.setState = function(state)
	{
		if (state!=OrganizationChartNode.prototype.STATE_COLLAPSED
		&&	state!=OrganizationChartNode.prototype.STATE_EXPANDED)
		{
			return;
		}
		var node = this.getToggleElement();

		node.innerHTML = state;
		var childrenTBody = this.getChildrenTBody();
		childrenTBody.style.display = 
			(state==OrganizationChartNode.prototype.STATE_COLLAPSED)
		?	"none"
		:	(this.getChildCount()==0)
		?	"none"
		:	"none"	
		;
	}
/*
*	OrganizationChartNode OrganizationChartNode.getChildNode(position)
*
*	purpose:
*		returns the childnode at the specified position
*	arguments:
*		position: 0 based integer index
*	returns:
*		a child OrganizationChartNode or null if that does not exist.
*	usage:
*		Navigate through the hierarchy
*
*/
	OrganizationChartNode.prototype.getChildNode = function(position)
	{
		var childrenContainer = this.getChildrenContainer();
		if (position < childrenContainer.cells.length)
		{
			return getFirstChildElement(
				childrenContainer.cells[position]
			).organizationChartNode;
		}
		return null;
	}
/*
*	int OrganizationChartNode.getChildCount()
*
*	purpose:
*		returns the number of childnodes
*	arguments:
*		none
*	returns:
*		an integer, representing the number of childnodes.
*	usage:
*		Navigate through the hierarchy
*
*/			
	OrganizationChartNode.prototype.getChildCount = function()
	{
		var childrenContainer = this.getChildrenContainer();
		return childrenContainer.cells.length;
	}
/*
*	void OrganizationChartNode.addChildNode(OrganizationChartNode,position)
*
*	purpose:
*		adds a node to the childnodes collection at the specified position
*	arguments:
*		OrganizationChartNode: the child node
*		position: where to insert
*	returns:
*		nothing
*	usage:
*		creating a hierarchy of multiple nodes.
*
*/			
	OrganizationChartNode.prototype.addChildNode = function(childOrganizationChartNode,position)
	{
		var childrenContainer = this.getChildrenContainer();
		var cell = childrenContainer.insertCell(position);
		cell.className = "CSS_NODE_CHILD";
		childOrganizationChartNode.addToContainer(cell);

		childOrganizationChartNode.renderAttachmentToParent();
		var childCount = childrenContainer.cells.length;

		if(childCount==1)
		{
			if (this.getState()==OrganizationChartNode.prototype.STATE_EXPANDED)
			{
				this.getChildrenTBody().style.display = "";
				if(this.enableToggle == 'true')
				{
				    this.getChildrenRow().style.display = "";
				}
				else
				{
				    this.getChildrenRow().style.display = "none";
				}
			}
		}
		else 
		{
			if (cell.cellIndex==0)
			{
				getFirstChildElement(cell.nextSibling).organizationChartNode.renderAttachmentToParent();
			}
			else if (cell.cellIndex == (childCount-1))
			{
				getFirstChildElement(cell.previousSibling).organizationChartNode.renderAttachmentToParent();
			}
		}
		this.setChildCount(childCount);
	}
/*
*	OrganizationChartNode OrganizationChartNode.removeChildNode(position)
*
*	purpose:
*		removes a node from the childnodes collection at the specified position
*	arguments:
*		position: which node to remove
*	returns:
*		the removed node, or null if there was no such node
*	usage:
*		modifying a hierarchy of multiple nodes.
*
*/
	OrganizationChartNode.prototype.removeChildNode = function(position)
	{
		var childNode = this.getChildNode(position);
		if (childNode==null)
		{
			return null;
		}
		childNode.removeFromContainer();
		return childNode;
	}
	