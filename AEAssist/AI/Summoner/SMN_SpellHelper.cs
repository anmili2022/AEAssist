using AEAssist.Helper;
using ff14bot.Managers;
namespace AEAssist.AI.Summoner
{
    public static class SMN_SpellHelper
    {

        public static bool Debugging { get; set; } = true;

        public static bool HasCarbuncle()
        {

            if (GameObjectManager.PetObjectId != GameObjectManager.EmptyGameObject)
                return true;
            if (AnyPet())
                return true;
            return false;
        }
        public static bool PhoenixTrance()
        {
            return ActionResourceManager.Summoner.AvailablePets.HasFlag(ActionResourceManager.Summoner.AvailablePetFlags.Phoenix);
        }

        public static bool NotMovingWhileSavingInstantSpells()
        {
            return DataBinding.Instance.SaveInstantSpells && (MovementManager.IsMoving);
        }


        public static bool CheckUseAOE()
        {
            return TargetHelper.CheckNeedUseAOE(25, 5);
        }
        public static bool AnyPet()
        {
            return Titan() || Ifrit() || Garuda();
        }
        public static bool Titan()
        {
            return ActionResourceManager.Summoner.ActivePet == ActionResourceManager.Summoner.ActivePetType.Titan;
        }

        public static bool Ifrit()
        {
            return ActionResourceManager.Summoner.ActivePet == ActionResourceManager.Summoner.ActivePetType.Ifrit;
        }

        public static bool Garuda()
        {
            return ActionResourceManager.Summoner.ActivePet == ActionResourceManager.Summoner.ActivePetType.Garuda;
        }
    }
}