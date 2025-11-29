public abstract class AProjectile {
    private string Name { get; set; }
    private int Dmg { get; set; }
    private int Speed { get; set; }
    public abstract void Move();
}