/**
 * 
 */
package csc2a.model;


/**
 * @author SAKHILE
 *
 */
public class CharacterFactory implements IFactory {

	@Override
	public GameObject producePlayer(int h) {
		// TODO Auto-generated method stub
		return new Player(h);
		
	}

	@Override
	public GameObject produceEnemy() {
		// TODO Auto-generated method stub
		return new Enemy();
		
	}

	@Override
	public GameObject produceRoad() {
		// TODO Auto-generated method stub
		return new Road();
	}

	@Override
	public GameObject produceFlag() {
		// TODO Auto-generated method stub
		return new Flag();
	}

}
