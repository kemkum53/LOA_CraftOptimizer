using CraftOptimizer.Properties;
using Google.OrTools.LinearSolver;

namespace CraftOptimizer;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        cmx_farmType.SelectedIndex = (int)Enum.Parse(typeof(FarmType), Storage.Default.DefaultFarmtype);
    }

    private void cmx_farmType_SelectedIndexChanged(object sender, EventArgs e)
    {
        var type = (FarmType)Enum.Parse(typeof(FarmType), cmx_farmType.Items[cmx_farmType.SelectedIndex].ToString());
        Storage.Default.DefaultFarmtype = type.ToString();
        Storage.Default.Save();
        LoadImages(type);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(tbx_mat1.Text)) tbx_mat1.Text = "0";
        if (string.IsNullOrWhiteSpace(tbx_mat2.Text)) tbx_mat2.Text = "0";
        if (string.IsNullOrWhiteSpace(tbx_mat3.Text)) tbx_mat3.Text = "0";
        if (string.IsNullOrWhiteSpace(tbx_mat4.Text)) tbx_mat4.Text = "0";

        int A_init = int.Parse(tbx_mat1.Text);
        int B_init = int.Parse(tbx_mat2.Text);
        int C_init = int.Parse(tbx_mat3.Text);
        int D_init = int.Parse(tbx_mat4.Text);

        Solver solver = Solver.CreateSolver("SCIP");
        if (solver == null)
        {
            lbl_conv1.Text = "err";
            lbl_conv2.Text = "err";
            lbl_conv3.Text = "err";
            lbl_conv4.Text = "err";
            return;
        }

        var crafts = solver.MakeIntVar(0, double.PositiveInfinity, "crafts");
        var b_to_d = solver.MakeIntVar(0, double.PositiveInfinity, "b_to_d");
        var c_to_d = solver.MakeIntVar(0, double.PositiveInfinity, "c_to_d");
        var d_to_a = solver.MakeIntVar(0, double.PositiveInfinity, "d_to_a");
        var d_to_b = solver.MakeIntVar(0, double.PositiveInfinity, "d_to_b");

        var D_created = b_to_d * 80 + c_to_d * 80;
        var D_used = d_to_a * 100 + d_to_b * 100;
        var D_available = D_init + D_created - D_used;

        var A_available = A_init + d_to_a * 10;
        var B_available = B_init - b_to_d * 50 + d_to_b * 50;
        var C_available = C_init - c_to_d * 100;

        solver.Add(A_available >= 33 * crafts);
        solver.Add(B_available >= 45 * crafts);
        solver.Add(C_available >= 86 * crafts);
        solver.Add(D_available >= 0);

        solver.Maximize(crafts);

        var resultStatus = solver.Solve();

        if (resultStatus == Solver.ResultStatus.OPTIMAL)
        {
            int total = (int)crafts.SolutionValue();
            int b_d = (int)b_to_d.SolutionValue();
            int c_d = (int)c_to_d.SolutionValue();
            int d_a = (int)d_to_a.SolutionValue();
            int d_b = (int)d_to_b.SolutionValue();

            lbl_total.Text = "x" + total.ToString();
            lbl_conv1.Text = "x" + b_d.ToString();
            lbl_conv2.Text = "x" + c_d.ToString();
            lbl_conv3.Text = "x" + d_a.ToString();
            lbl_conv4.Text = "x" + d_b.ToString();
        }
        else
        {
            lbl_conv1.Text = "err";
            lbl_conv2.Text = "err";
            lbl_conv3.Text = "err";
            lbl_conv4.Text = "err";
        }

    }

    private void tbx_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            e.Handled = true;
    }

    private void LoadImages(FarmType type)
    {
        switch (type)
        {
            case FarmType.Foraging:
                pic_mat1.Image = Resources.fro_mat1;
                pic_mat1_1.Image = Resources.fro_mat1;
                pic_mat2.Image = Resources.fro_mat2;
                pic_mat2_1.Image = Resources.fro_mat2;
                pic_mat2_1.Image = Resources.fro_mat2;
                pic_mat2_2.Image = Resources.fro_mat2;
                pic_mat3.Image = Resources.fro_mat3;
                pic_mat3_1.Image = Resources.fro_mat3;
                pic_mat4.Image = Resources.fro_mat4;
                pic_mat4_1.Image = Resources.fro_mat4;
                pic_mat4_2.Image = Resources.fro_mat4;
                pic_mat4_3.Image = Resources.fro_mat4;
                pic_mat4_4.Image = Resources.fro_mat4;
                break;
            case FarmType.Logging:
                pic_mat1.Image = Resources.log_mat1;
                pic_mat1_1.Image = Resources.log_mat1;
                pic_mat2.Image = Resources.log_mat2;
                pic_mat2_1.Image = Resources.log_mat2;
                pic_mat2_1.Image = Resources.log_mat2;
                pic_mat2_2.Image = Resources.log_mat2;
                pic_mat3.Image = Resources.log_mat3;
                pic_mat3_1.Image = Resources.log_mat3;
                pic_mat4.Image = Resources.log_mat4;
                pic_mat4_1.Image = Resources.log_mat4;
                pic_mat4_2.Image = Resources.log_mat4;
                pic_mat4_3.Image = Resources.log_mat4;
                pic_mat4_4.Image = Resources.log_mat4;
                break;
            case FarmType.Mining:
                pic_mat1.Image = Resources.min_mat1;
                pic_mat1_1.Image = Resources.min_mat1;
                pic_mat2.Image = Resources.min_mat2;
                pic_mat2_1.Image = Resources.min_mat2;
                pic_mat2_1.Image = Resources.min_mat2;
                pic_mat2_2.Image = Resources.min_mat2;
                pic_mat3.Image = Resources.min_mat3;
                pic_mat3_1.Image = Resources.min_mat3;
                pic_mat4.Image = Resources.min_mat4;
                pic_mat4_1.Image = Resources.min_mat4;
                pic_mat4_2.Image = Resources.min_mat4;
                pic_mat4_3.Image = Resources.min_mat4;
                pic_mat4_4.Image = Resources.min_mat4;
                break;
            case FarmType.Hunting:
                pic_mat1.Image = Resources.hun_mat1;
                pic_mat1_1.Image = Resources.hun_mat1;
                pic_mat2.Image = Resources.hun_mat2;
                pic_mat2_1.Image = Resources.hun_mat2;
                pic_mat2_1.Image = Resources.hun_mat2;
                pic_mat2_2.Image = Resources.hun_mat2;
                pic_mat3.Image = Resources.hun_mat3;
                pic_mat3_1.Image = Resources.hun_mat3;
                pic_mat4.Image = Resources.hun_mat4;
                pic_mat4_1.Image = Resources.hun_mat4;
                pic_mat4_2.Image = Resources.hun_mat4;
                pic_mat4_3.Image = Resources.hun_mat4;
                pic_mat4_4.Image = Resources.hun_mat4;
                break;
            case FarmType.Fishing:
                pic_mat1.Image = Resources.fis_mat1;
                pic_mat1_1.Image = Resources.fis_mat1;
                pic_mat2.Image = Resources.fis_mat2;
                pic_mat2_1.Image = Resources.fis_mat2;
                pic_mat2_1.Image = Resources.fis_mat2;
                pic_mat2_2.Image = Resources.fis_mat2;
                pic_mat3.Image = Resources.fis_mat3;
                pic_mat3_1.Image = Resources.fis_mat3;
                pic_mat4.Image = Resources.fis_mat4;
                pic_mat4_1.Image = Resources.fis_mat4;
                pic_mat4_2.Image = Resources.fis_mat4;
                pic_mat4_3.Image = Resources.fis_mat4;
                pic_mat4_4.Image = Resources.fis_mat4;
                break;
            case FarmType.Excavating:
                pic_mat1.Image = Resources.exc_mat1;
                pic_mat1_1.Image = Resources.exc_mat1;
                pic_mat2.Image = Resources.exc_mat2;
                pic_mat2_1.Image = Resources.exc_mat2;
                pic_mat2_1.Image = Resources.exc_mat2;
                pic_mat2_2.Image = Resources.exc_mat2;
                pic_mat3.Image = Resources.exc_mat3;
                pic_mat3_1.Image = Resources.exc_mat3;
                pic_mat4.Image = Resources.exc_mat4;
                pic_mat4_1.Image = Resources.exc_mat4;
                pic_mat4_2.Image = Resources.exc_mat4;
                pic_mat4_3.Image = Resources.exc_mat4;
                pic_mat4_4.Image = Resources.exc_mat4;
                break;
            default:
                break;
        }
    }
}

public enum FarmType
{
    Foraging = 0,
    Logging,
    Mining,
    Hunting,
    Fishing,
    Excavating
}
