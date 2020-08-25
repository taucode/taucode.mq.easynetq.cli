(defblock :name stop-subscriber :is-top t
	(executor
		:executor-name stop-subscriber
		:verb "stop"
		:description "Stops the subscriber."
		:usage-samples (
			"sub stop"))

	(end)
)
