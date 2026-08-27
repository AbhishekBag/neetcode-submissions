public class TimeMap {
    public Dictionary<string, TimeBucket> map;

    public TimeMap() {
        map = new Dictionary<string, TimeBucket>();
    }
    
    public void Set(string key, string value, int timestamp) {
        if(!map.ContainsKey(key)) {
            map[key] = new TimeBucket(timestamp, value);
        } else {
            map[key].AddItem(timestamp, value);
        }
    }
    
    public string Get(string key, int timestamp) {
        if(!map.ContainsKey(key)) {
            return "";
        }

        return map[key].GetItem(timestamp);
    }
}

public class TimeBucket {
    public List<int> timestamps = new List<int>();
    public Dictionary<int, string> timeMap = new Dictionary<int, string>();

    public TimeBucket(int time, string value) {
        timestamps.Add(time);
        timeMap[time] = value;
    }

    public void AddItem(int time, string value) {
        timestamps.Add(time);
        timeMap[time] = value;
    }

    public string GetItem(int time) {
        if(timeMap.ContainsKey(time)) {
            return timeMap[time];
        }

        if(time < timestamps[0]) {
            return "";
        }

        int validTime = GetNextMin(time);
        return timeMap[validTime];
    }

    public int GetNextMin(int target) {
        int l = 0, r = timestamps.Count - 1;

        while(l <= r) {
            int mid = l + (r - l)/2;
            if(timestamps[mid] == target) {
                return timestamps[mid];
            }

            if(timestamps[mid] < target) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }

            // 2, 4, 6, 8, 10
            // 1
        }
        
        return timestamps[l - 1];
    }
}