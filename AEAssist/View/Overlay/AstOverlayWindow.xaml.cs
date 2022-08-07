using AEAssist.AI;
using AEAssist.Define;
using AEAssist.Helper;
using PropertyChanged;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AEAssist.View.Overlay

{
    [AddINotifyPropertyChangedInterface]
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class AstOverlayWindow : UserControl
    {
        public Action DragMove;

        public AstOverlayWindow()
        {
            InitializeComponent();
        }

        private void AstOverlayWindow_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // this.DragMove();
            }
        }

        // Surecast
        private void UseSureCast_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = SpellsDefine.Surecast.GetSpellEntity();
        }

        // Sprint
        private void UseSprint_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = SpellsDefine.Sprint.GetSpellEntity();
            AIRoot.GetBattleData<BattleData>().NextAbilityUsePotion = false;
        }

        private void UsePotion_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilityUsePotion = true;
        }
        // EarthlyStar
        private void UseEarthlyStar_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = SpellsDefine.EarthlyStar.GetSpellEntity();
        }
        // Macrocosmos
        private void UseMacrocosmos_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextGcdSpellId = new SpellEntity(SpellsDefine.Macrocosmos, SpellTargetType.Self);
        }
        // Helios
        private void UseHelios_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextGcdSpellId = new SpellEntity(SpellsDefine.Helios, SpellTargetType.Self);
        }
        // AspectedHelios
        private void UseAspectedHelios_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextGcdSpellId = new SpellEntity(SpellsDefine.AspectedHelios, SpellTargetType.Self);
        }
        private void UseBeneficII_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextGcdSpellId = new SpellEntity(SpellsDefine.Benefic2, SpellTargetType.CurrTarget);
        }
       


        private void Expander_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove?.Invoke();
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            OverlayManager.OverlayManager.Instance.Close();
        }
    }
}

