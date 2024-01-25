using Sentry;

namespace SentryPoc.Utils
{
    public static class SentryExtension
    {
        public static SentryId SentToSentry(this Exception ex) => SentrySdk.CaptureException(ex);

        public static SentryId SentToSentry(this string msg) => SentrySdk.CaptureMessage(msg);
    }
}
