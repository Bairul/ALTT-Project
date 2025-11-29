public abstract class AEntity {
    private string Name { get; set; }
    private int Hp { get; set; }
    private int Str { get; set; }
    private int Speed { get; set; }
    public abstract void Move();
}