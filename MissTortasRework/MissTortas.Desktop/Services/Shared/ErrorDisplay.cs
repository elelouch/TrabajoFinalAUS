using MissTortas.Desktop.Services.DTO;

namespace MissTortas.Desktop.Services.Shared
{
    public static class ErrorDisplay
    {
        public static void Show(IWin32Window owner, Exception ex)
        {
            var (caption, message, icon) = ex switch
            {
                ApiException apiEx => (
                    apiEx.Problem.Title ?? "Error",
                    BuildMessage(apiEx.Problem),
                    MessageBoxIcon.Warning),

                _ => (
                    "Unexpected Error",
                    "Something went wrong. Please try again.",
                    MessageBoxIcon.Error)
            };

            MessageBox.Show(owner, message, caption, MessageBoxButtons.OK, icon);
        }

        private static string BuildMessage(ProblemDetailsDto problem)
        {
            var msg = problem.Detail ?? "The request could not be completed.";
            return problem.Status is not null ? $"{msg}\n\n(Error code: {problem.Status})" : msg;
        }
    }
}
