/**
 * 
 */
package csc2a.model;

/**
 * @author SAKHILE
 *
 */
public interface IFactory {
	public GameObject producePlayer(int health);
	public GameObject produceEnemy();
	public GameObject produceRoad();
	public GameObject produceFlag();
	

}
