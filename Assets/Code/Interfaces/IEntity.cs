public interface IEntity {
    private string Name { get; set; }
    private int Hp { get; set; }
    private int Str { get; set; }
    private int Speed { get; set; }
    public void Move();
}