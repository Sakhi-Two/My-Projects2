/**
 * 
 */
package csc2a.model;

import csc2a.designpatterns.iRenderVisitor;

/**
 * @author SAKHILE
 *
 */
public class Flag extends GameObject{
	
	public Flag() {
		super();
	}

	@Override
	public void accept(iRenderVisitor visitor) {
		// TODO Auto-generated method stub
		visitor.render(this);
	}

}
