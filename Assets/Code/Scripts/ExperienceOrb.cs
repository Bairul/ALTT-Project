using UnityEngine;

public class ExperienceOrb : CollectibleItem
{
    public int xpValue = 4;

    protected override void OnCollect(GameObject collector)
    {
        base.OnCollect(collector);
        ExperienceController experienceController = collector.GetComponent<ExperienceController>();

        if (experienceController)
        {
            experienceController.AddExperience(xpValue);
        }
    }
}
