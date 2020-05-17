using SimpleJSON;

namespace TEDinc.UniBlocks
{
    public interface ISaveable
    {
        JSONObject GetDataToSave();

        void SetDataFromSave(JSONObject data);
    }
}